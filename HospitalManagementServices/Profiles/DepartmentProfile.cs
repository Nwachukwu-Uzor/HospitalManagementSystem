using AutoMapper;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Dtos.Incoming.Departments;
using HospitalManagementServices.Dtos.Outgoing.Departments;

namespace HospitalManagementServices.Profiles
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
