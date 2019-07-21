using System.Collections.Generic;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.GetEmployees
{
    public class GetEmployees : IRequest<IEnumerable<Employee>>
    {
    }
}
