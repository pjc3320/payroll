using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll.Application.Models
{
    public class PagedResult<T> where T : class
    {
        public PagedResult(int page, int total, IEnumerable<T> data)
        {
            Page = page;
            Total = total;
            Data = data.ToList();
        }

        public int Page { get; set; }

        public int Total { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
