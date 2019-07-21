using System;
using Couchbase;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Payroll.Application.Couchbase
{
    public class EntityHelper<T> : IEntityHelper<T>
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        private readonly JsonSerializer _serializer = JsonSerializer.Create(_serializerSettings);

        public EntityHelper(string type)
        {
            Type = type;
        }

        public string Type { get; }

        public Func<T, Guid> GetEntityId { get; }

        public string DocumentIdFor(Guid entityId)
        {
            return $"{Type}::{entityId}";
        }

        public string DocumentIdFor(T entity)
        {
            return DocumentIdFor(GetEntityId(entity));
        }

        public Document<JObject> GetDocument(T entity)
        {
            var result = JObject.FromObject(entity, _serializer);
            result.Add("_type", Type);

            return new Document<JObject>
            {
                Id = DocumentIdFor(entity),
                Content = result,
                Expiry = 0
            };
        }
    }
}
