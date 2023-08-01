namespace MyWebBank.Application.DTO.Card
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Number { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVV { get; set; }

        public Guid AccountId { get; set; }
    }
}
