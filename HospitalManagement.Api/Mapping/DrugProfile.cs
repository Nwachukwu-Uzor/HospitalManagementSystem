using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Api.Dtos.Responses;
using HospitalManagement.Data.Entities;

namespace HospitalManagement.Api.Mapping
{
    public class DrugProfile : Profile
    {
        public DrugProfile()
        {
            CreateMap<DrugCreationDto, Drug>();
            CreateMap<Drug, DrugRequestDto>();
        }
    }
}
