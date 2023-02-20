using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Features.Queries.CompanyQueries.GetAllCompany;
using OrderManagement.Application.Repositories.CompanyRepositories;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, GetAllCompanyQueryResponse>
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        public GetAllCompanyQueryHandler(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }

        //public async Task<List<Domain.Entities.Company>> Handle(GetAllCompanyQueryRequest request,
        //    CancellationToken cancellationToken)
        //{
        //    var company = await _companyReadRepository.GetAll().ToListAsync();
        //    return company;
        //}
        public Task<GetAllCompanyQueryResponse> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var companies = _companyReadRepository.GetAll().ToList();
            var response = new GetAllCompanyQueryResponse();
            response.Companies = companies;
            return Task.FromResult(response);
        }
    }
}