using AutoMapper;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Patients;
using HospitalManagement.Services.Dtos.Outgoing.Patients;

namespace HospitalManagement.Services.Profiles
{
    public class PatientProfiles : Profile
    {
        public PatientProfiles()
        {
            CreateMap<PatientCreationDto, Patient>()
                .ForMember(dest => dest.EmailConfirmed, option => option.MapFrom(src => true))
                .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email));  

            CreateMap<Patient, PatientRequestDto>()
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex.ToString()))
                .ForMember(dest => dest.Genotype, opt => opt.MapFrom(src => src.Genotype.ToString()))
                .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => src.BloodGroup.ToString()));
        }
    }
}
