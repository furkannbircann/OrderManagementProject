using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Application.Repositories.CompanyRepositories;
using OrderManagement.Application.Repositories.OrderRepositories;

namespace OrderManagement.Application.Features.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICompanyReadRepository _companyReadRepository;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request,
            CancellationToken cancellationToken)
        {
            Domain.Entities.Company company = await _companyReadRepository.GetByIdAsync(request.CompanyId);
            var orderStartTime = company.OrderStartTime.Hour;
            var orderFinishTime = company.OrderFinishTime.Hour;
            var orderDate = request.OrderDate.Hour;

            if (company.IsApproved == true)
            {
                if (orderDate > orderStartTime && orderDate < orderFinishTime)
                {
                    Domain.Entities.Order order = new()
                    {
                        CompanyId = request.CompanyId,
                        ProductId = request.ProductId,
                        OrdererName = request.OrdererName,
                        OrderDate = request.OrderDate
                    };
                    await _orderWriteRepository.AddAsync(order);
                    await _orderWriteRepository.SaveAsync();
                    return new();
                }
                throw new Exception("Firma şuan sipariş almıyor");

            }
            throw new Exception("Firma onaylı değil");
        }
    }
}
