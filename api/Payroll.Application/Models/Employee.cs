using System.Collections.Generic;

namespace Payroll.Application.Models
{
    public class Employee : Person
    {
        public override double BenefitCost => 1000;

        public override string Type => "employee";

        public IEnumerable<Dependent> Dependents { get; set; }
    }
}
