using MyWebBank.Domain.Entities;

namespace MyWebBank.Application.Interfaces
{
    public interface IAccountsRepository : IGenericRepository<Account>
    {
        Task<Account> GetAccountWithCardsAsync(Guid id);
    }
}
