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

            CreateMap<Doctor, DoctorRequestDto>()
                .ForMember(dest => dest.IdentityId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.User.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address))
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.User.Sex));

            CreateMap<DoctorRegistrationDto, AppUser>()
                .ForMember(dest => dest.EmailConfirmed, option => option.MapFrom(src => true))
                .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email));
        }
    }
}
