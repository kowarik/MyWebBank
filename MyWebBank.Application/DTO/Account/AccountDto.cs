namespace MyWebBank.Application.DTO.Account
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AppUserId { get; set; }
    }
}
