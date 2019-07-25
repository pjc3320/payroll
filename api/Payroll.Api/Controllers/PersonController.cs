using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application.GetEmployees;
using Payroll.Application.UpsertDependents;
using Payroll.Application.UpsertEmployee;

namespace Payroll.Api.Controllers
{
    [Route("people")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GetAll(GetEmployees request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        [Route("employees")]
        public async Task<IActionResult> Put([FromBody] UpsertEmployee request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut]
        [Route("dependents")]
        public async Task<IActionResult> PutDependent([FromBody] UpsertDependent request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}