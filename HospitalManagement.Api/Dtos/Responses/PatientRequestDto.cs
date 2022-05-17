using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Dtos.Responses
{
    public class PatientRequestDto
    {
        public Guid IdentityId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
