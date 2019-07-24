using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Repositories;
using Couchbase.Repositories.Implementations;
using Payroll.Application.Models;

namespace Payroll.Application
{
    public class DependentRepository : IDependentRepository
    {
        internal IRepository<Dependent> Dependents;

        public DependentRepository(IBucket bucket)
        {
            var entityDescription = new EntityHelper<Dependent>("dependent", e => e.Id.ToString());

            Dependents = new Repository<Dependent>(bucket, entityDescription);
        }
        public async Task<IEnumerable<Dependent>> GetAll(Guid employeeId)
        {
            var result = await Dependents.GetAllAsync($"employeeId = {employeeId.ToString()}");

            return result;
        }

        public async Task<Dependent> Get(Guid id)
        {
            var result = await Dependents.GetAsync(id.ToString());

            return result;
        }

        public async Task<Dependent> Upsert(Dependent dependent)
        {
            await Dependents.UpsertAsync(dependent);

            return dependent;
        }
    }
}
