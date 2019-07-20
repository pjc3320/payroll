using System;

namespace Payroll.Models
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
