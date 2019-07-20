using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payroll.Application.Models;

namespace Payroll.Application.Couchbase
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> Get(T model);

        Task<IEnumerable<T>> GetAll(string filter = null);

        Task<T> Upsert(T entity);
    }
}
