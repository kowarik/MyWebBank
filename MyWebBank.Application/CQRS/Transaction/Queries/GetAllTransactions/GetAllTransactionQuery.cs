using MediatR;
using MyWebBank.Application.DTO.Transaction;

namespace MyWebBank.Application.CQRS.Transaction.Queries.GetAllTransactions
{
    public record GetAllTransactionQuery : IRequest<IEnumerable<TransactionDto>>;
}
