using Payroll.Models;

namespace Payroll.Application
{
    public class GetPayrollDeductionResponse
    {
        public Employee Employee { get; set; }

        public float Deduction { get; set; }
    }
}
