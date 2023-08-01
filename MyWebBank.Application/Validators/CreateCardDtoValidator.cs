using FluentValidation;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.Validators
{
    public class CreateCardDtoValidator : AbstractValidator<CreateCardDto>
    {
        public CreateCardDtoValidator()
        {
            RuleFor(transaction => transaction.Name).NotNull().NotEmpty().Length(1, 100);
            RuleFor(transaction => transaction.AccountId).NotNull();
        }
    }
}