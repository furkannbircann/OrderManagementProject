using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Application.Repositories.CompanyRepositories;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Features.Commands.Company.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _companyWriteRepository;

        public CreateCompanyCommandHandler(ICompanyWriteRepository companyWriteRepository)
        {
            _companyWriteRepository = companyWriteRepository;
        }


        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            await _companyWriteRepository.AddAsync(new()
            {
                CompanyName = request.CompanyName,
                IsApproved = request.IsApproved,
                OrderStartTime = request.OrderStartTime,
                OrderFinishTime = request.OrderFinishTime
            });
            await _companyWriteRepository.SaveAsync();
            return new();
        }
    }
}
