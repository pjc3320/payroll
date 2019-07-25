using System;

namespace Payroll.Application.Models
{
    public abstract class Person
    {
        public abstract Guid Id { get; set; }

        public abstract string FirstName { get; set; }

        public abstract string LastName { get; set; }
    }
}
