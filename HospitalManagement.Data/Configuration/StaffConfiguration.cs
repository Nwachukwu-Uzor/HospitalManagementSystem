using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagement.Data.Configuration
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            var admin = new Staff
            {
                Id = "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                IdentificationNumber = "ST-1001123355",
                FirstName = "Hospital",
                MiddleName = "Default",
                LastName = "Admin",
                DepartmentId = Guid.Parse("2b212064-c708-44fd-a49a-6d138cdded37"),
                DepartmentNumber = "SEC-1122335566",
                Email = "admin@hospitalManagement.com",
                Sex = "Male",
                Address = "Hospital Management Location",
                PhoneNumber = "+2348064879196",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            admin.PasswordHash = PassGenerate(admin);

            builder.HasData(admin);
        }

        public string PassGenerate(Staff user)
        {
            var passHash = new PasswordHasher<Staff>();
            return passHash.HashPassword(user, "P@$$word!1");
        }
    }
}
