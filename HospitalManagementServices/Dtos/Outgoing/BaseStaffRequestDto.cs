using System;

namespace HospitalManagementServices.Dtos.Outgoing
{
    public class BaseStaffRequestDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RegisterationDate { get; set; }
        public string Department { get; set; }
        public string DepartmentNumber { get; set; }
    }
}
