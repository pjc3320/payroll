using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.AddEmployee
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployee, Employee>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public AddEmployeeHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(AddEmployee request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            if (employee.Id == Guid.Empty)
            {
                employee.Id = Guid.NewGuid();
            }

            return await _repository.Upsert(employee);
        }
    }
}
