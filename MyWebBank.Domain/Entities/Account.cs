namespace MyWebBank.Domain.Entities
{
    public class Account : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Card>? Cards { get; set; }
        public Guid AppUserId { get; set; }
    }
}
