using System;

namespace Payroll.Application.Models
{
    public abstract class BaseModel
    {
        public virtual string Type { get; }

        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
