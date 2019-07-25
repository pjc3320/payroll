using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.GetEmployees
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployees, PagedResult<Employee>>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeesHandler(IEmployeeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<PagedResult<Employee>> Handle(GetEmployees request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            var employees = result.ToList();

            return new PagedResult<Employee>(1, employees.Count, employees);
        }
    }
}
