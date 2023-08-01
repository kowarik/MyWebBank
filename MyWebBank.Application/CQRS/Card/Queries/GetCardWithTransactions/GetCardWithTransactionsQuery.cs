using MediatR;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.CQRS.Card.Queries.GetCardWithTransactions
{
    public record GetCardWithTransactionsQuery(Guid Id) : IRequest<CardWithTransactionsDto>;
}
