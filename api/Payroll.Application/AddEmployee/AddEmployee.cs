using System.Collections.Generic;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.AddEmployee
{
    public class AddEmployee : IRequest<Employee>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DependentCount { get; set; }

        public IEnumerable<Dependent> Dependents { get; set; }
    }
}
