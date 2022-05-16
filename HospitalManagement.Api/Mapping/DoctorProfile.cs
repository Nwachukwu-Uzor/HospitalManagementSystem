using AutoMapper;
using HospitalManagement.Api.Dtos.Requests;
using HospitalManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Mapping
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorRegistrationDto>();
            CreateMap<Doctor, DoctorRegistrationDto>();
        }
    }
}
