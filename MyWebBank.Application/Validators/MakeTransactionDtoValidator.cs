using FluentValidation;
using MyWebBank.Application.DTO.Transaction;

namespace MyWebBank.Application.Validators
{
    public class MakeTransactionDtoValidator : AbstractValidator<MakeTransactionDto>
    {
        public MakeTransactionDtoValidator()
        {
            RuleFor(transaction => transaction.Amount).NotNull().GreaterThan(0);
            RuleFor(transaction => transaction.Description).NotEmpty().NotNull().Length(1, 100);
            RuleFor(transaction => transaction.CardIdFrom).NotNull();
            RuleFor(transaction => transaction.CardIdTo).NotNull();
        }
    }
}
