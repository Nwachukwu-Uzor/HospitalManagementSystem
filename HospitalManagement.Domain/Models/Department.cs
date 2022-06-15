﻿using System;

namespace HospitalManagement.Domain.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string DepartmentInitials { get; set; }
        public string Description { get; set; }
        public string DepartmentNumber { get; set; }
    }
}