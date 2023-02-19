using MediatR;

namespace OrderManagement.Application.Features.Queries.Company.GetAllCompany
{
    public class GetAllCompanyQueryRequest : IRequest<List<Domain.Entities.Company>>
    {
    }
}
