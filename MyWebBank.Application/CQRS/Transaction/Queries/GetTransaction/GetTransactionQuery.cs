using MediatR;
using MyWebBank.Application.DTO.Transaction;

namespace MyWebBank.Application.CQRS.Transaction.Queries.GetTransaction
{
    public record GetTransactionQuery(Guid Id) : IRequest<TransactionDto>;
}
