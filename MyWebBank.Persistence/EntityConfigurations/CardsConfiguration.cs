using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Persistence.EntityConfigurations
{
    public class CardsConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasData(
                new Card
                {
                    Id = Guid.Parse("8a5d62bb-0811-402c-9000-97583a1b4ef6"),
                    Name = "Credit card Acc 1",
                    Balance = 1000,
                    Number = "1111222233334444",
                    ExpirationMonth = "01",
                    ExpirationYear = "25",
                    CVV = "123",
                    AccountId = Guid.Parse("1f67ea66-7ad3-4273-94d4-729cabafdffa"),
                },
                new Card
                {
                    Id = Guid.Parse("a53f1a4b-873f-466f-b08c-2009fc95b4f9"),
                    Name = "Credit card Acc 2",
                    Balance = 100000,
                    Number = "1111222233335555",
                    ExpirationMonth = "05",
                    ExpirationYear = "30",
                    CVV = "321",
                    AccountId = Guid.Parse("7159ce0a-cc4e-46c1-becf-29201240baff"),
                }
            );

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Balance)
                .IsRequired()
                .HasColumnType("decimal(15, 2)");

            builder.Property(c => c.Number)
                .IsRequired()
                .HasAnnotation("RegularExpression", @"\d{16}");

            builder.Property(c => c.ExpirationMonth)
                .IsRequired()
                .HasAnnotation("RegularExpression", @"^(0[1-9]|1[0-2])$");

            builder.Property(c => c.ExpirationYear)
                .IsRequired()
                .HasAnnotation("RegularExpression", @"^\d{2}$");

            builder.Property(c => c.CVV)
                .IsRequired()
                .HasAnnotation("RegularExpression", @"\d{3}");

            builder.Property(c => c.AccountId)
                .IsRequired();
        }
    }
}
