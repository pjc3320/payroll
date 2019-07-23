using System;

namespace Payroll.Application.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Dependents { get; set; }
    }
}
