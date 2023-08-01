using MediatR;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.CQRS.Card.Commands.CreateCard
{
    public class CreateCardCommand : CreateCardDto, IRequest<CardDto>
    {
    }
}
