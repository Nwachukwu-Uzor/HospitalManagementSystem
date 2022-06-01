using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Dtos.Responses
{
    public class AppointmentRequestDto
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string Description { get; set; }
    }
}
