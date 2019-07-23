using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.AddEmployee
{
    public class AddEmployee : IRequest<Employee>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Dependents { get; set; }
    }
}
