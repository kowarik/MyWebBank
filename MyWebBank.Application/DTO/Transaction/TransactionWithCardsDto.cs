using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.DTO.Transaction
{
    public class TransactionWithCardsDto : TransactionDto
    {
        public CardDto CardFrom { get; set; }
        public CardDto CardTo { get; set; }
    }
}
