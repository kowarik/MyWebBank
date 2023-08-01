using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebBank.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }

        [ForeignKey("CardFrom")]
        public Guid CardIdFrom { get; set; }
        public Card CardFrom { get; set; }
        [ForeignKey("CardTo")]
        public Guid CardIdTo { get; set; }
        public Card CardTo { get; set; }
    }
}
