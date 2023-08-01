namespace MyWebBank.Application.DTO.Transaction
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }

        public Guid CardIdFrom { get; set; }
        public Guid CardIdTo { get; set; }
    }
}
