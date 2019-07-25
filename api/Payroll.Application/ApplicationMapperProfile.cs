using AutoMapper;
using Payroll.Application.Models;
using Payroll.Application.UpsertDependents;

namespace Payroll.Application
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<UpsertEmployee.UpsertEmployee, Employee>().ReverseMap();
            CreateMap<UpsertDependent, Dependent>().ReverseMap();
        }
    }
}
