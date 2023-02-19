using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Features.Commands.OrderCommands.CreateOrder;
using System.Net;

namespace OrderManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost("createorder")]
        public async Task<IActionResult> Create(CreateOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
