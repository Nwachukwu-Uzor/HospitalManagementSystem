using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementData.Configuration
{
    public class StaffRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string> {
                    RoleId = "67228962-a44c-49a6-b89b-395dd92cf75a",
                    UserId = "300ddf19-95e6-4744-83e6-2aa5e1d444c0"
                },
                new IdentityUserRole<string> {
                    UserId = "300ddf19-95e6-4744-83e6-2aa5e1d444c0",
                    RoleId = "27fb1887-cf6f-45d8-83d1-c501d6054fd3"
                }
            );
        }
    }
}
