using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Services.Dtos.Incoming.Staff
{
    public class StaffAdminDto
    {
        [Required]
        [StringLength(14, ErrorMessage = "The identification number should be 14 characters long", MinimumLength = 14)]
        [RegularExpression(@"^[a-zA-z]{3}-[0-9]{10}$", ErrorMessage = "The identitfication number provided is not valid")]
        public string IdentificationNumber { get; set; }
    }
}
