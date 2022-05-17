using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Dtos.Requests
{
    public class PatientRegistrationRequest
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        [MinLength(4)]
        public string LastName { get; set; }

        [Required]
        [MinLength(7)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(4)]
        public string Sex { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }
    }
}
