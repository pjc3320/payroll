using System;

namespace Payroll.Application.Models
{
    public class Dependent : Person
    {
        public override Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }
    }
}
