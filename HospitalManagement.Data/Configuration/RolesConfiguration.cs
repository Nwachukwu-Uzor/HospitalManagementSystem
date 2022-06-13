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
                      Name = "Staff",
                      NormalizedName = "STAFF"
                  },
                 new IdentityRole
                 {
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 },
                 new IdentityRole {
                     Name = "SuperAdmin",
                     NormalizedName = "SUPERADMIN"
                 },
                new IdentityRole
                {
                    Name = "Patient",
                    NormalizedName = "PATIENT"
                }
            );  
        }
    }
}
