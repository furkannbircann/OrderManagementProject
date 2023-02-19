using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Features.Commands.Company.CreateCompany;
using OrderManagement.Application.Features.Commands.CompanyCommands.UpdateCompany;
using OrderManagement.Application.Features.Queries.Company.GetAllCompany;

namespace OrderManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompaniesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var companies = await mediator.Send(new GetAllCompanyQueryRequest());
            return Ok(companies);
        }

        [HttpPost("createcompany")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("updatecompany")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}

