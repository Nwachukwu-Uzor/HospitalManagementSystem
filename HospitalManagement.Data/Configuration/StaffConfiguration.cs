using HospitalManagement.Domain.Enums;
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
            var hasher = new PasswordHasher<AppUser>();
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
                NormalizedEmail = "ADMIN@HOSPITALMANAGEMENT.COM",
                UserName = "admin@hospitalManagement.com",
                NormalizedUserName = "ADMIN@HOSPITALMANAGEMENT.COM",
                Sex = Gender.MALE,
                Address = "Hospital Management Location",
                PhoneNumber = "+2348064879196",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "P@$$word1")
            };

            builder.HasData(admin);
        }
    }
}
