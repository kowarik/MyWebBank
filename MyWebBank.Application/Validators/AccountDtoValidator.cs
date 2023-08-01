using FluentValidation;
using MyWebBank.Application.DTO.Account;

namespace MyWebBank.Application.Validators
{
    public class AccountDtoValidator : AbstractValidator<AccountDto>
    {
        public AccountDtoValidator()
        {
            RuleFor(transaction => transaction.Id).NotNull();
            RuleFor(transaction => transaction.AppUserId).NotNull();
            RuleFor(transaction => transaction.CreatedAt).NotNull();
        }
    }
}
