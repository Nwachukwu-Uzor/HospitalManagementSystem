using HospitalManagementDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementData.Configuration
{
    public class DepartmentsConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department {
                    Id = Guid.Parse("7da11ee0-2519-493f-816a-ba6f46aacb74"),
                    Name = "Outpatient Department",
                    DepartmentInitials = "OTP",
                    Description = "This section of the hospital caters for patients that require medical attention but are not" +
                    "required to be admitted are treated",
                    DepartmentNumber = "OTP-1122334455"
                },
                new Department
                {
                    Id = Guid.Parse("7cd042ca-c443-4067-91c1-6d1df0fad8d5"),
                    Name = "Inpatient Department",
                    DepartmentInitials = "INP",
                    Description = "This section of the hospital caters for patients that are required to be admitted for at least one night",
                    DepartmentNumber = "INP-1122334466"
                },
                new Department
                {
                    Id = Guid.Parse("368faff2-f91f-4de3-a9b9-ac6e659ced57"),
                    Name = "Physicians Department",
                    DepartmentInitials = "PHY",
                    Description = "This section of the hospital contains all the doctors in the hospital",
                    DepartmentNumber = "PHY-1122334477"
                },
                new Department
                {
                    Id = Guid.Parse("a0a2e6c6-3fee-46dc-a87e-dcb215029e93"),
                    Name = "Nursing Department",
                    DepartmentInitials = "NUR",
                    Description = "This section of the hospital contains all the nurses in the hospital",
                    DepartmentNumber = "NUR-1122334488"
                },
                new Department
                {
                    Id = Guid.Parse("12757ffa-ab81-4a23-b3a1-4f3fc169ec53"),
                    Name = "Pharmarcy Department",
                    DepartmentInitials = "PHM",
                    Description = "This section of the hospital contains all the pharmacists in the hospital",
                    DepartmentNumber = "PHM-1122334499"
                },
                new Department
                {
                    Id = Guid.Parse("501c0200-3c6d-48c7-8b6e-964a87f0c290"),
                    Name = "Medical Laboratory Department",
                    DepartmentInitials = "MLA",
                    Description = "This section of the hospital contains all the laboratory scientists and radiologists in the hospital",
                    DepartmentNumber = "MLA-1122335511"
                },
                new Department
                {
                    Id = Guid.Parse("295d3a0c-992c-4dfb-bcc2-e26fb6f9b4b8"),
                    Name = "Accounts Department",
                    DepartmentInitials = "ACC",
                    Description = "This section of the hospital contains all the accountants in the hospital",
                    DepartmentNumber = "ACC-1122335522"
                },
                 new Department
                 {
                     Id = Guid.Parse("91c4ebd1-33ae-4ef2-aeee-1d12e01d3dfb"),
                     Name = "Records Department",
                     DepartmentInitials = "RCD",
                     Description = "This section of the hospital is tasked with managing all the records in the hospital",
                     DepartmentNumber = "RCD-1122335533"
                 },
                  new Department
                  {
                      Id = Guid.Parse("55ccc95d-caac-44fe-b3ee-8830184ee9b5"),
                      Name = "Janitorial Department",
                      DepartmentInitials = "JNT",
                      Description = "This section of the hospital contains all the maintenance and cleaning staff in the hospital",
                      DepartmentNumber = "JNT-1122335544"
                  },
                  new Department
                  {
                      Id = Guid.Parse("2b212064-c708-44fd-a49a-6d138cdded37"),
                      Name = "Security Department",
                      DepartmentInitials = "SEC",
                      Description = "This section of the hospital contains all the security officers in the hospital",
                      DepartmentNumber = "SEC-1122335566"
                  }
            );
        }
    }
}
