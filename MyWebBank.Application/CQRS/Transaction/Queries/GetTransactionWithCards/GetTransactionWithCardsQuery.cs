using MediatR;
using MyWebBank.Application.DTO.Transaction;

namespace MyWebBank.Application.CQRS.Transaction.Queries.GetTransactionWithCards
{
    public record GetTransactionWithCardsQuery(Guid Id) : IRequest<TransactionWithCardsDto>;
}
