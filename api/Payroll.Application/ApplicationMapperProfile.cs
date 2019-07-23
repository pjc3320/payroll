using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using Payroll.Application.Models;

namespace Payroll.Application
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<AddEmployee.AddEmployee, Employee>().ReverseMap();
        }
    }
}
