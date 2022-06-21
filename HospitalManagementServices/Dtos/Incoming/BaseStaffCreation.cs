using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementServices.Dtos.Incoming
{
    public class BaseStaffCreation : BaseUserCreation
    {
        [Required]
        public string DepartmentNumber { get; set; }
    }
}
