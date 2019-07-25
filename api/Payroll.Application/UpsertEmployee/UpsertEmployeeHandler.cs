using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.UpsertEmployee
{
    public class UpsertEmployeeHandler : IRequestHandler<UpsertEmployee, Employee>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public UpsertEmployeeHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Employee> Handle(UpsertEmployee request, CancellationToken cancellationToken)
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
