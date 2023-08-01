using MediatR;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.CQRS.Card.Queries.GetUserCards
{
    public record GetUserCardsQuery : IRequest<IEnumerable<CardDto>>;
}
