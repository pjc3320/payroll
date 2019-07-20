using System.Collections.Generic;
using MediatR;
using Payroll.Models;

namespace Payroll.Application.GetEmployees
{
    public class GetEmployees : IRequest<IEnumerable<Employee>>
    {
    }
}
