using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Dtos.Outgoing.Departments
{
    public class DepartmentRequestDto
    {
        public string Name { get; set; }
        public string DepartmentInitials { get; set; }
        public string Description { get; set; }
        public string DepartmentNumber { get; set; }
    }
}
