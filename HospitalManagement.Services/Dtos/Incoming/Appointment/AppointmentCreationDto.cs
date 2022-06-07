using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Services.Dtos.Incoming.Appointment
{
    public class AppointmentCreationDto
    {
        [Required]
        public string DoctorIdentityNumber { get; set; }

        [Required]
        public string PatientIdentityNumber { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
