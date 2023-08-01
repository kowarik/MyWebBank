using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebBank.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Number { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVV { get; set; }

        public Guid AccountId { get; set; }
        public IEnumerable<Transaction> SendedTransactions { get; set; }
        public IEnumerable<Transaction> RecievedTransactions { get; set; }
    }
}
