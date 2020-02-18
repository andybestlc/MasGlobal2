using AutoMapper;
using MasGlobal.Dto;
using MasGlobal.Model;
using MasGLobal.Model;

namespace MasGlobal.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<SalaryType, SalaryTypeDto>().ReverseMap();
          
        }
    }

}
