using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Payroll.Application
{
    public class GetPayrollDeductionHandler : IRequestHandler<GetPayrollDeductions, GetPayrollDeductionResponse>
    {
        public async Task<GetPayrollDeductionResponse> Handle(GetPayrollDeductions request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
