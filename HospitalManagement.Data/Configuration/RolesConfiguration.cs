using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagement.Data.Configuration
{
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                  new IdentityRole
                  {
                      Id = "27fb1887-cf6f-45d8-83d1-c501d6054fd3",
                      Name = "Staff",
                      NormalizedName = "STAFF"
                  },
                 new IdentityRole
                 {
                     Id = "5af1f3a1-f7f9-4ad0-b757-cda796199def",
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 },
                 new IdentityRole {
                     Id = "67228962-a44c-49a6-b89b-395dd92cf75a",
                     Name = "SuperAdmin",
                     NormalizedName = "SUPERADMIN"
                 },
                new IdentityRole
                {
                    Id = "a1ff4611-dc37-4a8e-af8e-73e764fc8676",
                    Name = "Patient",
                    NormalizedName = "PATIENT"
                }
            );  
        }
    }
}
