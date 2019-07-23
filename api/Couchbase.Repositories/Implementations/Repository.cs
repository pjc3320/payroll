using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.IO;

namespace Couchbase.Repositories.Implementations
{
    /// <inheritdoc />
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IBucket _bucket;
        private readonly IEntityHelper<T> _context;

        public Repository(IBucket bucket, IEntityHelper<T> entityHelper)
        {
            _bucket = bucket ?? throw new ArgumentNullException(nameof(bucket));
            _context = entityHelper ?? throw new ArgumentNullException(nameof(entityHelper));
        }

        private string BucketName => _bucket.Name;
        private string WhereEntity => $"WHERE _type='{_context.Type}'";

        public async Task<T> GetAsync(string entityId)
        {
            if (entityId == null) throw new ArgumentNullException(nameof(entityId));

            var documentId = _context.DocumentIdFor(entityId);
            var result = await _bucket.GetAsync<T>(documentId);

            if (result.Status == ResponseStatus.KeyNotFound) return null;

            result.ThrowIfFailure();
            return result.Value;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string filter = null)
        {
            filter = PrepareFilter(filter);
            var statement = $"SELECT {BucketName}.* FROM {BucketName} {WhereEntity}{filter}";

            var result = await _bucket.QueryAsync<T>(statement);
            result.ThrowIfFailure();
            return result.Rows;
        }

        public async Task RemoveAsync(string entityId)
        {
            if (entityId == null) throw new ArgumentNullException(nameof(entityId));

            var documentId = _context.DocumentIdFor(entityId);

            var result = await _bucket.RemoveAsync(documentId);
            result.ThrowIfFailure();
        }

        public async Task UpsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var document = _context.DocumentFor(entity);

            var result = await _bucket.UpsertAsync(document);
            result.ThrowIfFailure();
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var document = _context.DocumentFor(entity);

            var result = await _bucket.InsertAsync(document);
            result.ThrowIfFailure();
        }

        private static string PrepareFilter(string filter)
        {
            if (!string.IsNullOrEmpty(filter)) filter = $" AND {filter}";

            return filter;
        }
    }
}