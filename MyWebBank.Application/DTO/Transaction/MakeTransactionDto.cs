namespace MyWebBank.Application.DTO.Transaction
{
    public class MakeTransactionDto
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public Guid CardIdFrom { get; set; }
        public Guid CardIdTo { get; set; }
    }
}
