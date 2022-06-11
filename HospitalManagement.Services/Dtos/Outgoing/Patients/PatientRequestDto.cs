using System;

namespace HospitalManagement.Services.Dtos.Outgoing.Patients
{
    public class PatientRequestDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RegisterationDate { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
    }
}
