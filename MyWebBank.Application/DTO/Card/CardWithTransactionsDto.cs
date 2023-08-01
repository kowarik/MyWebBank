using MyWebBank.Application.DTO.Transaction;

namespace MyWebBank.Application.DTO.Card
{
    public class CardWithTransactionsDto : CardDto
    {
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}
