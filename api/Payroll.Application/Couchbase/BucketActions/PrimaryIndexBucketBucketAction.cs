using System.Threading.Tasks;
using Couchbase.Core;

namespace Payroll.Application.Couchbase.BucketActions
{
    public class PrimaryIndexBucketBucketAction : IBucketAction
    {
        private readonly IBucket _bucket;

        public PrimaryIndexBucketBucketAction(IBucket bucket)
        {
            _bucket = bucket;
        }

        public async Task Execute()
        {
            var manager = _bucket.CreateManager();
            var result = await manager.CreateN1qlPrimaryIndexAsync("IDX_Payroll", false);


            result.ThrowIfFailure();
        }
    }
}
