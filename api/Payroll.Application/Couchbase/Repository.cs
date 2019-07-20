using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;
using Payroll.Application.Models;

namespace Payroll.Application.Couchbase
{
    public abstract class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly IBucket _bucket;

        protected Repository(IBucket bucket)
        {
            _bucket = bucket;
        }

        public virtual async Task<T> Get(T model)
        {
            var result = await _bucket.GetDocumentAsync<T>(GenerateKey(model));

            return result.Content;
        }

        public virtual async Task<IEnumerable<T>> GetAll(string filter = null)
        {
            var n1ql = "select * from payroll where _type='user'";
            var queryRequest = new QueryRequest().Statement(n1ql);

            var result = await _bucket.QueryAsync<dynamic>(queryRequest);

            throw new NotImplementedException();
        }

        public virtual async Task<T> Upsert(T entity)
        {
            var document = new Document<T> {Content = entity, Id = GenerateKey(entity)};

            var result = await _bucket.UpsertAsync(document);

            return result.Content;
        }

        protected virtual string GenerateKey(T model)
        {
            return $"{model.Type}::{model.Id.ToString()}";
        }
    }
}