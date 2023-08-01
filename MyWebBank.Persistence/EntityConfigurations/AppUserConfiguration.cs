using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebBank.Infrastructure.Identity;

namespace MyWebBank.Persistence.EntityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser
                {
                    Id = Guid.Parse("8fd749c7-6da5-4f5b-901f-c339a6f04cd9"),
                    FirstName = "Kyrylo",
                    LastName = "Kyr",
                    UserAccountId = Guid.Parse("1f67ea66-7ad3-4273-94d4-729cabafdffa")
                },
                new AppUser
                {
                    Id = Guid.Parse("623cdba9-e456-4852-9484-8739393b532e"),
                    FirstName = "Mykola",
                    LastName = "Myk",
                    UserAccountId = Guid.Parse("7159ce0a-cc4e-46c1-becf-29201240baff")
                }
            );

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.UserAccountId)
                .IsRequired();
        }
    }
}
