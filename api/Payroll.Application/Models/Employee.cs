using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Payroll.Application.Models
{
    public class Employee : Person
    {
        private const double GrossAnnualSalary = 52000;

        public override Guid Id { get; set; }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        [JsonIgnore]
        public double Salary => GrossAnnualSalary;

        [JsonIgnore]
        public int DependentCount => Dependents.Count();

        public IEnumerable<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
