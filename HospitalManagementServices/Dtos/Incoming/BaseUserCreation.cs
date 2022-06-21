using HospitalManagementDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementServices.Dtos.Incoming
{
    public class BaseUserCreation
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
        [Range(0, 2, ErrorMessage = "Please pass in a valid sex")]
        public Gender Sex { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }
    }
}
