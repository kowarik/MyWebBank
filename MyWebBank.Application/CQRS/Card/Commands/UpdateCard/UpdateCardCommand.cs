using MediatR;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.CQRS.Card.Commands.UpdateCard
{
    public class UpdateCardCommand : UpdateCardDto, IRequest<CardDto>
    {
    }
}
