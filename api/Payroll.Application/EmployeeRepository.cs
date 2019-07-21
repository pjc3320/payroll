using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Core;
using Payroll.Application.Couchbase;
using Payroll.Application.Models;

namespace Payroll.Application
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IBucket _bucket;
        internal IRepository<Employee> Employees;

        public EmployeeRepository(IBucket bucket)
        {
            _bucket = bucket;
            var entityHelper = new EntityHelper<Employee>("employee");
            
            Employees = new Repository<Employee>(bucket, entityHelper);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await Employees.GetAll();
        }
    }
}
