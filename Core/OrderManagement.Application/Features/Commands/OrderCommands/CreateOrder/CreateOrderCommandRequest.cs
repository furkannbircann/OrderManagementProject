using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OrderManagement.Application.Features.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string OrdererName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
