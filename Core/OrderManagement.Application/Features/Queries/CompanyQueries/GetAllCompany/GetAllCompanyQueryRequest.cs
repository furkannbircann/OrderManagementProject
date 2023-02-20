using MediatR;
using OrderManagement.Application.Features.Queries.CompanyQueries.GetAllCompany;

namespace OrderManagement.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyQueryRequest : IRequest<GetAllCompanyQueryResponse>
    {
    }
}