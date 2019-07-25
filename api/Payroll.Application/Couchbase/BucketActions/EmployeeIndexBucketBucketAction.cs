using System;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Repositories.Implementations;

namespace Payroll.Application.Couchbase.BucketActions
{
    public class EmployeeIndexBucketBucketAction : IBucketAction
    {
        private readonly IBucket _bucket;

        public EmployeeIndexBucketBucketAction(IBucket bucket)
        {
            _bucket = bucket ?? throw new ArgumentNullException(nameof(bucket));
        }

        public async Task Execute()
        {
            var manager = _bucket.CreateManager();
            var fields = new[] { "_type" };

            var result = await manager.CreateN1qlIndexAsync("IDX_Payroll_Employee", false, fields);

            result.ThrowIfFailure();
        }
    }
}