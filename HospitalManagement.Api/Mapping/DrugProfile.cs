using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Mapping
{
    public class DrugProfile : Profile
    {
        public DrugProfile()
        {
            CreateMap<DrugCreationDto, Drug>();
        }
    }
}
