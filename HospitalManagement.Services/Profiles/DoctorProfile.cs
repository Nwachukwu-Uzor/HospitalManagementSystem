using AutoMapper;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Doctors;
using HospitalManagement.Services.Dtos.Outgoing.Doctors;

namespace HospitalManagement.Services.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
                CreateMap<DoctorCreationDto, Doctor>()
                  .ForMember(dest => dest.EmailConfirmed, option => option.MapFrom(src => true))
                    .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email));

                CreateMap<Doctor, DoctorRequestDto>()
                          .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                          .ForMember(dest => dest.DepartmentNumber, opt => opt.MapFrom(src => src.Department.DepartmentNumber))
                          .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex.ToString()));
        }
    }
}
