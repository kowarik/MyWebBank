using MediatR;
using MyWebBank.Application.DTO.Account;

namespace MyWebBank.Application.CQRS.Account.Queries.GetAccountWithCards
{
    public record GetAccountWithCardsQuery(Guid Id) : IRequest<AccountWithCardsDto>;
}
