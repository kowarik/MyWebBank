using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Persistence.Repositories
{
    public class AccountsRepository : GenericRepository<Account>, IAccountsRepository
    {
        public AccountsRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }

        public async Task<Account> GetAccountWithCardsAsync(Guid id)
        {
            var account = await _dbSet.Include(a => a.Cards).FirstOrDefaultAsync(a => a.Id == id);
            if (account == null)
            {
                throw new EntityNotFoundException("Account not found");
            }

            return account;
        }
    }
}
