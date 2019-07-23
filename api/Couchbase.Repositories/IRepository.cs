using System.Collections.Generic;
using System.Threading.Tasks;

namespace Couchbase.Repositories
{
    /// <summary>
    ///     A generic Couchbase repository.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string entityId);

        Task<IEnumerable<T>> GetAllAsync(string filter = null);

        Task RemoveAsync(string entityId);

        Task UpsertAsync(T entity);

        Task InsertAsync(T entity);
    }
}