using System;
using Newtonsoft.Json.Linq;

namespace Couchbase.Repositories.Implementations
{
    /// <summary>
    ///     Describes metadata about an entity of type <typeparamref name="T" /> in order to create Couchbase documents and related content.
    /// </summary>
    public class EntityHelper<T> : IEntityHelper<T>
    {
        public EntityHelper(string type, Func<T, string> idProvider, Func<T, uint> expirationProvider = null)
        {
            Type = type;
            IdProvider = idProvider;

            if (expirationProvider != null) ExpirationProvider = expirationProvider;
        }

        public string Type { get; }

        public Func<T, string> IdProvider { get; }

        public Func<T, uint> ExpirationProvider { get; } = x => 0;

        public string DocumentIdFor(T entity)
        {
            return DocumentIdFor(IdProvider(entity));
        }

        public string DocumentIdFor(string entityId)
        {
            return $"{Type}::{entityId}";
        }

        public JObject DocumentContentFor(T entity)
        {
            var result = entity.ToJObject();
            result.Add("_type", Type);
            return result;
        }

        public Document<JObject> DocumentFor(T entity)
        {
            return new Document<JObject>
            {
                Id = DocumentIdFor(entity),
                Content = DocumentContentFor(entity),
                Expiry = ExpirationProvider(entity)
            };
        }
    }
}