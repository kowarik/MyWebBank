namespace MyWebBank.Application.DTO.Card
{
    public class CreateCardDto
    {
        public string Name { get; set; }

        public Guid AccountId { get; set; }
    }
}
