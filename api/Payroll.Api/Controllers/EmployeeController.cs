using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application.AddEmployee;
using Payroll.Application.GetEmployees;

namespace Payroll.Api.Controllers
{
    [Route("employees")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetEmployees request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> Put(AddEmployee request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}