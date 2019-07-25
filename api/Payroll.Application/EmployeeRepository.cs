using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Repositories;
using Couchbase.Repositories.Implementations;
using Payroll.Application.Models;

namespace Payroll.Application
{
    public class EmployeeRepository : IEmployeeRepository
    {
        internal IRepository<Employee> Employees;

        public EmployeeRepository(IBucket bucket)
        {
            if (bucket == null)
            {
                throw new ArgumentNullException(nameof(bucket));
            }

            var entityDescription = new EntityHelper<Employee>("employee",e => e.Id.ToString());
            
            Employees = new Repository<Employee>(bucket, entityDescription);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await Employees.GetAllAsync();

            return result;
        }

        public async Task<Employee> Get(Guid id)
        {
            return await Employees.GetAsync(id.ToString());
        }

        public async Task<Employee> Upsert(Employee employee)
        {
            await Employees.UpsertAsync(employee);

            return employee;
        }
    }
}
