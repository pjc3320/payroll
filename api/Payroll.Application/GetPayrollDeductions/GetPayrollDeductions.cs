using System;
using MediatR;

namespace Payroll.Application.GetPayrollDeductions
{
    public class GetPayrollDeductions : IRequest<GetPayrollDeductionResponse>
    {
        public Guid EmployeeId { get; set; }
    }
}
