using MediatR;
using MyWebBank.Application.DTO.Account;

namespace MyWebBank.Application.CQRS.Account.Commands.CreateAccount
{
    public record CreateAccountCommand(Guid AppUserId): IRequest<AccountDto>;
}
