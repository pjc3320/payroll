using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payroll.Application.Models;

namespace Payroll.Application
{
    public interface IDependentRepository
    {
        Task<IEnumerable<Dependent>> GetAll(Guid employeeId);

        Task<Dependent> Get(Guid id);

        Task<Dependent> Upsert(Dependent employee);
    }
}
