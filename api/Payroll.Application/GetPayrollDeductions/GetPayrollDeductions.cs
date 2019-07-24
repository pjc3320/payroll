using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.GetPayrollDeductions
{
    public class GetPayrollDeductions : IRequest<GetPayrollDeductionResponse>
    {
        public Employee Employee { get; set; }
    }
}
