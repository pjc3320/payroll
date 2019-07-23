using System;
using Newtonsoft.Json.Linq;

namespace Couchbase.Repositories
{
    /// <summary>
    ///     Describes an entity with enough information to allow a Couchbase <see cref="Document{T}" /> to be created.
    /// </summary>
    public interface IEntityHelper<in T>
    {
        string Type { get; }

        Func<T, string> IdProvider { get; }

        Func<T, uint> ExpirationProvider { get; }

        string DocumentIdFor(T entity);

        string DocumentIdFor(string entityId);

        JObject DocumentContentFor(T entity);

        Document<JObject> DocumentFor(T entity);
    }
}