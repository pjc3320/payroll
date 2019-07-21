using System;

namespace Payroll.Application.Models
{
    public class Dependent : Person
    {
        public override double BenefitCost => 500;

        public override string Type => "dependent";

        public Guid EmployeeId { get; set; }

        public Relationship Relationship { get; set; }
    }
}
