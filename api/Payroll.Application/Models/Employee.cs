using System.Collections.Generic;

namespace Payroll.Models
{
    public class Employee : Person
    {
        private const int BenefitCost = 1000;

        public IEnumerable<Dependent> Dependents { get; set; }

    }
}
