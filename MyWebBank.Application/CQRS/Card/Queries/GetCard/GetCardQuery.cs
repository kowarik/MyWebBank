using MediatR;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.CQRS.Card.Queries.GetCard
{
    public record GetCardQuery(Guid Id) : IRequest<CardDto>;
}
