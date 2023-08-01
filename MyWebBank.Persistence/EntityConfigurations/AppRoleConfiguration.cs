using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebBank.Infrastructure.Identity;

namespace MyWebBank.Persistence.EntityConfigurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole
                {
                    Id = Guid.Parse("827fa58d-9fe1-4f4f-993f-737c8e3a12e2"),
                    Name = "User",
                    NormalizedName = "USER",
                },
                new AppRole
                {
                    Id = Guid.Parse("018ad483-2295-4235-b301-92698c297499"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                }
            );
        }
    }
}
