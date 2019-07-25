using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application.GetPayrollDeductions;

namespace Payroll.Api.Controllers
{
    [Route("payroll")]
    public class PayrollController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PayrollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets the deductions costs for an employee.
        /// </summary>
        /// <param name="request">The request.</param>
        [HttpGet]
        [Route("deductions")]
        public async Task<IActionResult> CalculateBenefitCosts([FromQuery] GetPayrollDeductions request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}