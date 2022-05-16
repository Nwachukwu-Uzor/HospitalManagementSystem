using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.Api.Dtos.Requests
{
    public class DoctorRegistrationDto
    {
        [Required]
        [StringLength(4)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        [StringLength(4)]
        public string LastName { get; set; }

        [Required]
        [StringLength(7)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        
        [Required]
        [StringLength(4)]
        public string Sex { get; set; }

        [Required]
        [StringLength(10)]
        public string Address { get; set; }
    }
}
