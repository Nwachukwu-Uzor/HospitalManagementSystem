using AutoMapper;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Departments;
using HospitalManagement.Services.Dtos.Outgoing.Departments;

namespace HospitalManagement.Services.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentCreationDto, Department>()
                .ForMember(dest => dest.DepartmentInitials, opt => opt.MapFrom(src => src.DepartmentInitials.ToUpper()));
            CreateMap<Department, DepartmentRequestDto>();
        }
    }
}
