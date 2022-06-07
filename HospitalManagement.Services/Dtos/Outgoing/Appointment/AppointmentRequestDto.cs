using System;

namespace HospitalManagement.Services.Dtos.Outgoing.Appointment
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
