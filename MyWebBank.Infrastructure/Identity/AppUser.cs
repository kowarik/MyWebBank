using Microsoft.AspNetCore.Identity;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Infrastructure.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserAccountId { get; set; }

        public Account Account { get; set; }
    }
}
