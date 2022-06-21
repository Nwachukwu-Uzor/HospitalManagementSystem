using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementServices.Dtos.Incoming.Departments
{
    public class DepartmentCreationDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Department name length should be between 5 and 50 characters", MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "Department initial should be 3 characters long", MinimumLength = 3)]
        public string DepartmentInitials { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Department description should be at least 10 characters long.")]
        public string Description { get; set; }
    }
}
