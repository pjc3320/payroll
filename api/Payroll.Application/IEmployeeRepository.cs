using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payroll.Application.Models;

namespace Payroll.Application
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> Get(Guid id);
    }
}
