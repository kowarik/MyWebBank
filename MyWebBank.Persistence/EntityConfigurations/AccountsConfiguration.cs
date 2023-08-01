using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Persistence.EntityConfigurations
{
    public class AccountsConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account
                {
                    Id = Guid.Parse("1f67ea66-7ad3-4273-94d4-729cabafdffa"),
                    CreatedAt = DateTime.Now,
                    AppUserId = Guid.Parse("8fd749c7-6da5-4f5b-901f-c339a6f04cd9"),
                },
                new Account
                {
                    Id = Guid.Parse("7159ce0a-cc4e-46c1-becf-29201240baff"),
                    CreatedAt = DateTime.Now,
                    AppUserId = Guid.Parse("623cdba9-e456-4852-9484-8739393b532e"),
                }
            );

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.AppUserId)
                .IsRequired();
        }
    }
}
