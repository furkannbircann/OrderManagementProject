using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Application.Repositories.CompanyRepositories;

namespace OrderManagement.Application.Features.Commands.CompanyCommands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _companyWriteRepository;
        private readonly ICompanyReadRepository _companyReadRepository;

        public UpdateCompanyCommandHandler(ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Company company = await _companyReadRepository.GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            else
            {
                company.IsApproved = request.IsApproved;
                company.OrderStartTime = request.OrderStartTime;
                company.OrderFinishTime = request.OrderFinishTime;
                _companyWriteRepository.Update(company);
                await _companyWriteRepository.SaveAsync();
                return new();
            }
        }
    }
}
