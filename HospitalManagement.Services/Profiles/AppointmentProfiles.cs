using AutoMapper;
using HospitalManagement.Domain.Models;
using HospitalManagement.Services.Dtos.Incoming.Appointment;
using HospitalManagement.Services.Dtos.Outgoing.Appointment;

namespace HospitalManagement.Services.Profiles
{
    public class AppointmentProfiles : Profile
    {
        public AppointmentProfiles()
        {
            CreateMap<AppointmentCreationDto, Appointment>()
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.Date));

            CreateMap<Appointment, AppointmentRequestDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => $"{src.Doctor.FirstName} {src.Doctor.LastName}"))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => $"{src.Patient.FirstName} {src.Patient.LastName}"));
        }
    }
}
