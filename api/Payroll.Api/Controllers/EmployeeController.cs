using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            // TODO: add index
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}