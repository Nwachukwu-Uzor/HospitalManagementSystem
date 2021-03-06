using HospitalManagementDomain.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace HospitalManagementDomain.Models
{
    public class AppUser : IdentityUser
    {
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }

        public Gender Sex { get; set; }
        public string Address { get; set; }
        public DateTime RegisterationDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
