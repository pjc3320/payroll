using System;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.UpsertDependents
{
    public class UpsertDependent : IRequest<Dependent>
    {
        public Guid EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
