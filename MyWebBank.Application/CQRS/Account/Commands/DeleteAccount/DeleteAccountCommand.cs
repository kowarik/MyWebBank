using MediatR;

namespace MyWebBank.Application.CQRS.Account.Commands.DeleteAccount
{
    public record DeleteAccountCommand(Guid Id) : IRequest<bool>;
}
