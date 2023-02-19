using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Repositories.CompanyRepositories;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, List<Domain.Entities.Company>>
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        public GetAllCompanyQueryHandler(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }

        public async Task<List<Domain.Entities.Company>> Handle(GetAllCompanyQueryRequest request,
            CancellationToken cancellationToken)
        {
            var company = await _companyReadRepository.GetAll().ToListAsync();
            return company;
        }
    }
}
