using FluentValidation;
using MyWebBank.Application.DTO.Transaction;

namespace MyWebBank.Application.Validators
{
    public class TransactionDtoValidator : AbstractValidator<TransactionDto>
    {
        public TransactionDtoValidator()
        {
            RuleFor(transaction => transaction.Id).NotNull();
            RuleFor(transaction => transaction.Amount).NotNull().GreaterThan(0);
            RuleFor(transaction => transaction.Description).NotEmpty().NotNull().Length(1, 100);
            RuleFor(transaction => transaction.TransactionStatus).NotEmpty().NotNull();
            RuleFor(transaction => transaction.TransactionDate).NotNull();
            RuleFor(transaction => transaction.CardIdFrom).NotNull();
            RuleFor(transaction => transaction.CardIdTo).NotNull();
        }
    }
}
