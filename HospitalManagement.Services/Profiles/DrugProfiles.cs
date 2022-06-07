using AutoMapper;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Drugs;
using HospitalManagement.Services.Dtos.Outgoing.Drugs;

namespace HospitalManagement.Services.Profiles
{
    public class DrugProfiles : Profile
    {
        public DrugProfiles()
        {
            CreateMap<DrugCreationDto, Drug>();
            CreateMap<Drug, DrugRequestDto>();
            CreateMap<DrugUpdateDto, Drug>();
        }
    }
}
