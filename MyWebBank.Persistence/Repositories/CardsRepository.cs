using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Persistence.Repositories
{
    public class CardsRepository : GenericRepository<Card>, ICardsRepository
    {
        public CardsRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<Card>> GetUserCardsAsync()
        {
            return await _dbSet.Where(c => c.AccountId == UserId).ToListAsync();
        }

        public async Task<Card> GetCardWithTransactionsAsync(Guid id)
        {
            var card = await _dbSet.Include(c => c.SendedTransactions).Include(c => c.RecievedTransactions).FirstOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                throw new EntityNotFoundException("Card not found");
            }

            return card;
        }
    }
}
