using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Payroll.Data
{
    public interface IRepository<T>
    {
        Task<T> Get(Guid id);

        Task<IEnumerable<T>> GetAll();

        Task<T> Upsert(T entity);
    }
}
