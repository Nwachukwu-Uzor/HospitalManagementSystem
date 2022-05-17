using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Api.Mapping
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorRegistrationDto, Doctor>();
            CreateMap<Doctor, DoctorRequestDto>();
            CreateMap<DoctorRegistrationDto, IdentityUser>()
                .ForMember(dest => dest.EmailConfirmed, option => option.MapFrom(src => true))
                .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email));
        }
    }
}
