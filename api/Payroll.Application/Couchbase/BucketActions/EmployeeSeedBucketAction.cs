using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payroll.Application.Models;

namespace Payroll.Application.Couchbase.BucketActions
{
    public class EmployeeSeedBucketAction : IBucketAction
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDependentRepository _dependentRepository;

        public EmployeeSeedBucketAction(IEmployeeRepository employeeRepository, IDependentRepository dependentRepository)
        {
            _employeeRepository = employeeRepository;
            _dependentRepository = dependentRepository;
        }

        public async Task Execute()
        {
            var employees = new List<Employee>();
            // add an employee with a discount plus two dependents with discounts
            // hard code employeeIds so we don't get dupes in the bucket
            var employeeId = new Guid("01bb18a9-bf9b-4866-bae4-ed4ea2947cc2");
            var firstEmployeeDependents = new List<Dependent>
            {
                new Dependent
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employeeId,
                    FirstName = "Alice",
                    LastName = "Doe"
                },
                new Dependent
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employeeId,
                    FirstName = "Alison",
                    LastName = "Doe"
                },
                new Dependent
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employeeId,
                    FirstName = "Billy",
                    LastName = "Doe"
                }
            };

            var firstEmployee = new Employee
            {
                Id = employeeId,
                FirstName = "Alan",
                LastName = "Lots-O-Discounts",
                Dependents = firstEmployeeDependents
            };

            firstEmployeeDependents.ForEach(async d => await _dependentRepository.Upsert(d));

            employees.Add(firstEmployee);
            
            // add an employee with only dependent discounts
            employeeId = new Guid("1362b8b2-c6d1-4a1c-a994-de2493d0c1bf");
            var secondEmployeeDependents = new List<Dependent>
            {
                new Dependent
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employeeId,
                    FirstName = "Alice",
                    LastName = "Ann"
                }
            };

            var secondEmployee = new Employee
            {
                Id = employeeId,
                FirstName = "Adam",
                LastName = "Family-Discounts",
                Dependents = secondEmployeeDependents
            };

            secondEmployeeDependents.ForEach(async d => await _dependentRepository.Upsert(d));

            employees.Add(secondEmployee);

            // add an employee with no dependents
            var thirdEmployee = new Employee
            {
                Id = new Guid("2d18be0f-9e0b-4afb-8855-153e9b1dde77"),
                FirstName = "Billy",
                LastName = "Buckets"
            };

            employees.Add(thirdEmployee);

            employees.ForEach(async e => await _employeeRepository.Upsert(e));
        }
    }
}
