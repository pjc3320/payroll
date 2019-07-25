using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.GetPayrollDeductions
{
    public class GetPayrollDeductionHandler : IRequestHandler<GetPayrollDeductions, GetPayrollDeductionResponse>
    {
        private const int PayPeriods = 26;
        private const double AnnualDeductionCost = 1000;
        private const double DependentAnnualCost = 500;
        private const double SpecialDiscountPercent = 0.10;
        private readonly IEmployeeRepository _employeeRepository;

        public GetPayrollDeductionHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<GetPayrollDeductionResponse> Handle(GetPayrollDeductions request,
            CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.Get(request.EmployeeId);

            var dependentCost = employee.DependentCount * DependentAnnualCost -
                                employee.Dependents.Count(e => e.FirstName.StartsWith("A")) * DependentAnnualCost *
                                SpecialDiscountPercent;
            var employeeCost = employee.FirstName.StartsWith("A")
                ? AnnualDeductionCost - AnnualDeductionCost * SpecialDiscountPercent
                : AnnualDeductionCost;

            var result = new GetPayrollDeductionResponse
            {
                Employee = employee,
                DeductionDetail = new DeductionDetail
                {
                    AnnualDeductions = dependentCost + employeeCost,
                    AnnualSalary = employee.Salary,
                    PeriodDeductions = Math.Round((dependentCost + employeeCost) / PayPeriods, 2),
                    PeriodSalary = Math.Round(employee.Salary / PayPeriods, 2)
                }
            };

            return result;
        }
    }
}