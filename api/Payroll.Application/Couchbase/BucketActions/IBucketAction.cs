using System.Threading.Tasks;
using Couchbase.Core;

namespace Payroll.Application.Couchbase.BucketActions
{
    /// <summary>
    /// Simple contract to perform actions against a Couchbase <see cref="IBucket"/>
    /// </summary>
    public interface IBucketAction
    {
        Task Execute();
    }
}
