using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Persistence.EntityConfigurations
{
    public class TransactionsConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData(
                new Transaction
                {
                    Id = Guid.Parse("dc19eb3a-e3bc-452d-9f0c-4f35e92aab81"),
                    Amount = 228,
                    Description = "gift to 2",
                    TransactionStatus = "Success",
                    TransactionDate = DateTime.Now,
                    CardIdFrom = Guid.Parse("8a5d62bb-0811-402c-9000-97583a1b4ef6"),
                    CardIdTo = Guid.Parse("a53f1a4b-873f-466f-b08c-2009fc95b4f9"),
                },
                new Transaction
                {
                    Id = Guid.Parse("956ff8ee-141f-4925-95c7-e2c239130f7b"),
                    Amount = 1234,
                    Description = "gift to 1",
                    TransactionStatus = "Success",
                    TransactionDate = DateTime.Now,
                    CardIdFrom = Guid.Parse("a53f1a4b-873f-466f-b08c-2009fc95b4f9"),
                    CardIdTo = Guid.Parse("8a5d62bb-0811-402c-9000-97583a1b4ef6"),
                }
            );

            builder
                .HasOne(t => t.CardTo)
                .WithMany(c => c.RecievedTransactions)
                .HasForeignKey(t => t.CardIdTo)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(t => t.CardFrom)
                .WithMany(c => c.SendedTransactions)
                .HasForeignKey(t => t.CardIdFrom)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(c => c.Amount)
                .IsRequired()
                .HasColumnType("decimal(15, 2)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.TransactionStatus)
                .IsRequired();

            builder.Property(c => c.TransactionDate)
                .IsRequired();

            builder.Property(c => c.CardIdFrom)
                .IsRequired();

            builder.Property(c => c.CardIdTo)
                .IsRequired();
        }
    }
}
