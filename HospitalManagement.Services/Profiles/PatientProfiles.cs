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
                .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email))
                .ForMember(dest => dest.Genotype, option => option.MapFrom(src => src.Genotype.ToUpper()))
                .ForMember(dest => dest.BloodGroup, option => option.MapFrom(src => src.BloodGroup.ToUpper()));  

            CreateMap<Patient, PatientRequestDto>();

            CreateMap<PatientCreationDto, AppUser>()
                .ForMember(dest => dest.EmailConfirmed, option => option.MapFrom(src => true))
                .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email));
        }
    }
}
