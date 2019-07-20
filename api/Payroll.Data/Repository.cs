using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Core;

namespace Payroll.Data
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly IBucket _bucket;

        protected Repository(IBucket bucket)
        {
            _bucket = bucket;
        }

        public async Task<T> Get(Guid id)
        {
            var result = await _bucket.GetDocumentAsync<T>(id.ToString());

            return result.Content;
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
