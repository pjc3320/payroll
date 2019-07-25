using System;
using System.Collections.Generic;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.UpsertEmployee
{
    public class UpsertEmployee : IRequest<Employee>
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DependentCount { get; set; }

        public IEnumerable<Dependent> Dependents { get; set; }
    }
}
