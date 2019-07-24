using AutoMapper;
using Payroll.Application.AddDependents;
using Payroll.Application.Models;

namespace Payroll.Application
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<AddEmployee.AddEmployee, Employee>().ReverseMap();
            CreateMap<AddDependent, Dependent>().ReverseMap();
        }
    }
}
