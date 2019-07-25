using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Payroll.Application.GetPayrollDeductions;
using Payroll.Application.Models;
using Xunit;

namespace Payroll.Application.Tests
{
    public class GetPayrollDeductionHandlerTests
    {
        private readonly GetPayrollDeductionHandler _handler;
        private readonly Mock<IEmployeeRepository> _employeeRepository = new Mock<IEmployeeRepository>();

        public GetPayrollDeductionHandlerTests()
        {
            _handler = new GetPayrollDeductionHandler(_employeeRepository.Object);
        }

        [Fact]
        public async Task Handle_WithEmployeeDiscountAndDependentDiscount_Succeeds()
        {
            // arrange
            const double expectedDeductionTotal = 1350;
            const double expectedDeductionForPeriod = 51.92;

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Adam",
                LastName = "Andrews",
                Dependents = new List<Dependent>
                {
                    new Dependent
                    {
                        FirstName = "Anna",
                        LastName = "Doe",
                        Id = Guid.NewGuid()
                    }
                }
            };

            var request = new GetPayrollDeductions.GetPayrollDeductions
            {
                EmployeeId = employee.Id
            };

            _employeeRepository.Setup(x => x.Get(It.Is<Guid>(g => g == employee.Id))).ReturnsAsync(employee);

            // act
            var result = await _handler.Handle(request, new CancellationToken());

            //assert
            Assert.Single(result.Employee.Dependents);
            Assert.Equal(expectedDeductionTotal, result.DeductionDetail.AnnualDeductions);
            Assert.Equal(expectedDeductionForPeriod, result.DeductionDetail.PeriodDeductions);
        }

        [Fact]
        public async Task Handle_WithNoEmployeeDiscountAndDependentDiscount_Succeeds()
        {
            // arrange
            const double expectedDeductionTotal = 1900;
            const double expectedDeductionForPeriod = 73.08;

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Billy",
                LastName = "Baldwin",
                Dependents = new List<Dependent>
                {
                    new Dependent
                    {
                        FirstName = "Anna",
                        LastName = "Doe",
                        Id = Guid.NewGuid()
                    },
                    new Dependent
                    {
                        FirstName = "Alice",
                        LastName = "AndChains",
                        Id = Guid.NewGuid()
                    }
                }
            };

            var request = new GetPayrollDeductions.GetPayrollDeductions
            {
                EmployeeId = employee.Id
            };

            _employeeRepository.Setup(x => x.Get(It.Is<Guid>(g => g == employee.Id))).ReturnsAsync(employee);

            // act
            var result = await _handler.Handle(request, new CancellationToken());

            //assert
            Assert.Equal(2, result.Employee.Dependents.Count());
            Assert.Equal(expectedDeductionTotal, result.DeductionDetail.AnnualDeductions);
            Assert.Equal(expectedDeductionForPeriod, result.DeductionDetail.PeriodDeductions);
        }

        [Fact]
        public async Task Handle_WithEmployeeDiscountOnlyAndNoDependents_Succeeds()
        {
            // arrange
            const double expectedDeductionTotal = 900;
            const double expectedDeductionForPeriod = 34.62;

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Adam",
                LastName = "Andrews"
            };

            var request = new GetPayrollDeductions.GetPayrollDeductions
            {
                EmployeeId = employee.Id
            };

            _employeeRepository.Setup(x => x.Get(It.Is<Guid>(g => g == employee.Id))).ReturnsAsync(employee);

            // act
            var result = await _handler.Handle(request, new CancellationToken());

            //assert
            Assert.Empty(result.Employee.Dependents);
            Assert.Equal(expectedDeductionTotal, result.DeductionDetail.AnnualDeductions);
            Assert.Equal(expectedDeductionForPeriod, result.DeductionDetail.PeriodDeductions);
        }

        [Fact]
        public async Task Handle_WithEmployeeNoDiscountsAndNoDependents_Succeeds()
        {
            // arrange
            const double expectedDeductionTotal = 1000;
            const double expectedDeductionForPeriod = 38.46;

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Billy",
                LastName = "Blanks"
            };

            var request = new GetPayrollDeductions.GetPayrollDeductions
            {
                EmployeeId = employee.Id
            };

            _employeeRepository.Setup(x => x.Get(It.Is<Guid>(g => g == employee.Id))).ReturnsAsync(employee);

            // act
            var result = await _handler.Handle(request, new CancellationToken());

            //assert
            Assert.Empty(result.Employee.Dependents);
            Assert.Equal(expectedDeductionTotal, result.DeductionDetail.AnnualDeductions);
            Assert.Equal(expectedDeductionForPeriod, result.DeductionDetail.PeriodDeductions);
        }
    }
}
