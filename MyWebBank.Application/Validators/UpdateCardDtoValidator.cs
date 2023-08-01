using FluentValidation;
using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.Validators
{
    public class UpdateCardDtoValidator : AbstractValidator<UpdateCardDto>
    {
        public UpdateCardDtoValidator()
        {
            RuleFor(transaction => transaction.Id).NotNull();
            RuleFor(transaction => transaction.Name).NotNull().NotEmpty().Length(1, 100);
        }
    }
}
