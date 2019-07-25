using System.Threading.Tasks;

namespace Payroll.Application.Couchbase.BucketActions
{
    public interface IBucketAction
    {
        Task Execute();
    }
}
