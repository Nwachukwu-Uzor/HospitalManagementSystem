using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Domain.Models
{
    public class Staff : AppUser
    {
        public string DepartmentNumber { get; set; }

        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
