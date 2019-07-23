using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.Application.Couchbase
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(Guid entityId);

        Task<IEnumerable<T>> GetAll(string filter = null);

        Task<T> Upsert(T entity);
    }
}
