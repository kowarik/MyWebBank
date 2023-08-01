using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using Transaction = MyWebBank.Domain.Entities.Transaction;

namespace MyWebBank.Persistence.Repositories
{
    public class TransactionsRepository : GenericRepository<Transaction>, ITransactionsRepository
    {
        private readonly ICardsRepository _cardsRepository;
        public TransactionsRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, ICardsRepository cardsRepository) : base(dbContext, httpContextAccessor)
        {
            _cardsRepository = cardsRepository;
        }

        public async Task<Transaction> MakeTransactionAsync(Transaction transaction)
        {
            using var dbTransaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var cardFrom = await _cardsRepository.GetByIdAsync(transaction.CardIdFrom);
                var cardTo = await _cardsRepository.GetByIdAsync(transaction.CardIdTo);

                if (cardFrom == null || cardTo == null)
                {
                    throw new EntityNotFoundException("One or both cards not found");
                }

                if (cardFrom.Balance < transaction.Amount)
                {
                    throw new BadRequestException("Insufficient funds in the source card");
                }

                cardFrom.Balance -= transaction.Amount;
                cardTo.Balance += transaction.Amount;

                transaction.TransactionStatus = "Success";
                transaction.TransactionDate = DateTime.Now;

                await _cardsRepository.UpdateAsync(cardFrom);
                await _cardsRepository.UpdateAsync(cardTo);
                await CreateAsync(transaction);

                await dbTransaction.CommitAsync();

                return transaction;
            }
            catch (EntityNotFoundException)
            {
                await dbTransaction.RollbackAsync();
                throw;
            }
            catch (BadRequestException)
            {
                await dbTransaction.RollbackAsync();
                throw;
            }
            catch (Exception)
            {
                await dbTransaction.RollbackAsync();
                throw;
            }
            finally
            {
                dbTransaction.Dispose();
            }
        }

        public async Task<Transaction> GetTransactiontWithCardsAsync(Guid id)
        {
            var transaction = await _dbSet.Include(a => a.CardFrom).Include(a => a.CardIdTo).FirstOrDefaultAsync(a => a.Id == id);
            if (transaction == null)
            {
                throw new EntityNotFoundException("Transaction not found");
            }

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetUserTransactionsAsync()
        {
            return await _dbSet.Include(t => t.CardFrom).Include(t => t.CardTo).Where(d => d.CardFrom.AccountId == AccountId || d.CardTo.AccountId == AccountId).ToListAsync();
        }
    }
}
