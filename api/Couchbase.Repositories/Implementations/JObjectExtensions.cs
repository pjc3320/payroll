using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Couchbase.Repositories.Implementations
{
    /// <summary>
    ///     JObject related extension methods.
    /// </summary>
    public static class JObjectExtensions
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
            { ContractResolver = new CamelCasePropertyNamesContractResolver()} ;

        private static readonly JsonSerializer Serializer = JsonSerializer.Create(SerializerSettings);

        public static JObject ToJObject(this object o)
        {
            return JObject.FromObject(o, Serializer);
        }
    }
}