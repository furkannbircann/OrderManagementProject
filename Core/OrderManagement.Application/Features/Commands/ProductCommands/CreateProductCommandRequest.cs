using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OrderManagement.Application.Features.Commands.ProductCommands
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal? Price { get; set; }
    }
}
