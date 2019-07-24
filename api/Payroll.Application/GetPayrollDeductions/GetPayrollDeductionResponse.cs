using Payroll.Application.Models;

namespace Payroll.Application.GetPayrollDeductions
{
    public class GetPayrollDeductionResponse
    {
        public Employee Employee { get; set; }

        public DeductionDetail DeductionDetail { get; set; }
    }
}
