using MediatR;
using MyWebBank.Application.DTO.Transaction;

namespace MyWebBank.Application.CQRS.Transaction.Commands.MakeTransaction
{
    public class MakeTransactionCommand : MakeTransactionDto, IRequest<TransactionDto>
    {
    }
}
