using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Features.Commands.ProductCommands;

namespace OrderManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost("createproduct")]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
