using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Couchbase.BucketActions
{
    public interface IBucketAction
    {
        Task Execute();
    }
}
