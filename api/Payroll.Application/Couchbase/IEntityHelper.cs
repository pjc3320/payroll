using System;
using System.Collections.Generic;
using System.Text;
using Couchbase;
using Newtonsoft.Json.Linq;

namespace Payroll.Application.Couchbase
{
    public interface IEntityHelper<in T>
    {
        string Type { get; }

        Func<T, Guid> GetEntityId { get; }

        string DocumentIdFor(Guid entityId);

        string DocumentIdFor(T entity);

        Document<JObject> GetDocument(T entity);
    }

}
