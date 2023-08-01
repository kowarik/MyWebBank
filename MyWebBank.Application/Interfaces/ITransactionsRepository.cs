using MyWebBank.Domain.Entities;

namespace MyWebBank.Application.Interfaces
{
    public interface ITransactionsRepository : IGenericRepository<Transaction>
    {
        /// <summary>
        /// Make money transfer (add money to the recipient and take money away from the sender), Add transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<Transaction> MakeTransactionAsync(Transaction transaction);

        Task<Transaction> GetTransactiontWithCardsAsync(Guid id);

        Task<IEnumerable<Transaction>> GetUserTransactionsAsync();
    }
}
