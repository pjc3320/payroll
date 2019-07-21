using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.N1QL;
using Payroll.Application.Models;

namespace Payroll.Application.Couchbase
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly IBucket _bucket;
        private readonly IEntityHelper<T> _entityHelper;

        protected Repository(IBucket bucket, IEntityHelper<T> entityHelper)
        {
            _bucket = bucket;
            _entityHelper = entityHelper;
        }

        public async Task<T> Get(Guid entityId)
        {
            var documentId = _entityHelper.DocumentIdFor(entityId);
            var result = await _bucket.GetDocumentAsync<T>(documentId);

            result.ThrowIfFailure();

            return result.Content;
        }

        public async Task<IEnumerable<T>> GetAll(string filter = null)
        {
            var n1ql = $"select * from payroll where _type='{_entityHelper.Type}'";
            var queryRequest = new QueryRequest().Statement(n1ql);

            var result = await _bucket.QueryAsync<T>(queryRequest);

            result.ThrowIfFailure();

            return result.Rows;
        }

        public async Task Upsert(T entity)
        {
            var document = _entityHelper.GetDocument(entity);

            var result = await _bucket.UpsertAsync(document);

            result.ThrowIfFailure();
        }
    }
}