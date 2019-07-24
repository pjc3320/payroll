using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Payroll.Application.GetPayrollDeductions
{
    public class GetPayrollDeductionHandler : IRequestHandler<GetPayrollDeductions, GetPayrollDeductionResponse>
    {
        private const double AnnualDeductionCost = 1000;
        private const double DependentAnnualCost = 500;
        private const double SpecialDiscountPercent = 0.10;

        public async Task<GetPayrollDeductionResponse> Handle(GetPayrollDeductions request, CancellationToken cancellationToken)
        {
            return new GetPayrollDeductionResponse();
        }
    }
}
