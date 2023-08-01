using MediatR;

namespace MyWebBank.Application.CQRS.Card.Commands.DeleteCard
{
    public record DeleteCardCommand(Guid Id) : IRequest<bool>;
}
