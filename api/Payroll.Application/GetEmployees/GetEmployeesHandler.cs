using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.GetEmployees
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployees, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeesHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployees request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();

            return result;
        }
    }
}
