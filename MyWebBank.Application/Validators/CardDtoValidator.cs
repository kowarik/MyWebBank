using FluentValidation;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.Validators
{
    public class CardDtoValidator : AbstractValidator<CardDto>
    {
        public CardDtoValidator()
        {
            RuleFor(transaction => transaction.Id).NotNull();
            RuleFor(transaction => transaction.Name).NotNull().NotEmpty().Length(1, 100);
            RuleFor(transaction => transaction.Balance).NotNull().GreaterThan(0);
            RuleFor(transaction => transaction.Number).NotEmpty().NotNull().Matches(@"\d{16}");
            RuleFor(transaction => transaction.ExpirationMonth).NotNull().NotEmpty().Matches(@"^(0[1-9]|1[0-2])$");
            RuleFor(transaction => transaction.ExpirationYear).NotNull().NotEmpty().Matches(@"^\d{2}$");
            RuleFor(transaction => transaction.CVV).NotNull().NotEmpty().Matches(@"\d{3}");
            RuleFor(transaction => transaction.AccountId).NotNull();
        }
    }
}
