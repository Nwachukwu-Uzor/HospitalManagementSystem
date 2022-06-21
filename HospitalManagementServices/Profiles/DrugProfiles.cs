using AutoMapper;
using HospitalManagementDomain.Models;
using HospitalManagementServices.Dtos.Incoming.Drugs;
using HospitalManagementServices.Dtos.Outgoing.Drugs;

namespace HospitalManagementServices.Profiles
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
