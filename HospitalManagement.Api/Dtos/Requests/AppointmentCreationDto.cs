using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Dtos.Requests
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
