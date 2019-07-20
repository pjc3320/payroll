using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application;

namespace Payroll.Api.Controllers
{
    [Route("payroll")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
       [HttpGet]
       public async Task<IActionResult> CalculateBenefitCosts(GetPayrollDeductions request)
        {
            throw new NotImplementedException();
        }
    }
}
