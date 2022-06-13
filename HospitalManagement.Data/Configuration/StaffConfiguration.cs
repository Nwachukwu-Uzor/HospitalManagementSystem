using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagement.Data.Configuration
{
    public class StaffConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var admin = new Staff
            {
                IdentificationNumber = "ST-1001123355",
                FirstName = "Hospital",
                MiddleName = "Default",
                LastName = "Admin",
                DepartmentId = Guid.Parse("2b212064-c708-44fd-a49a-6d138cdded37"),
                Email = "admin@hospitalManagement.com",
                Sex = "Male",
                Address = "Hospital Management Location",
            };

            admin.PasswordHash = PassGenerate(admin);

            builder.HasData(admin);
        }

        public string PassGenerate(Staff user)
        {
            var passHash = new PasswordHasher<AppUser>();
            return passHash.HashPassword(user, "P@$$word!1");
        }
    }
}
