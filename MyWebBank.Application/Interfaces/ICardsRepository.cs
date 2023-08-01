using MyWebBank.Domain.Entities;

namespace MyWebBank.Application.Interfaces
{
    public interface ICardsRepository : IGenericRepository<Card>
    {
        Task<IEnumerable<Card>> GetUserCardsAsync();
        Task<Card> GetCardWithTransactionsAsync(Guid id);
    }
}
