using AutoMapper;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Dtos.Incoming.Staff;
using HospitalManagementServices.Dtos.Outgoing.Staff;

namespace HospitalManagementServices.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffCreationDto, Staff>()
                .ForMember(dest => dest.EmailConfirmed, option => option.MapFrom(src => true))
                .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email)); 

            CreateMap<Staff, StaffRequestDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.DepartmentNumber, opt => opt.MapFrom(src => src.Department.DepartmentNumber));
        }
    }
}
