using MyWebBank.Application.DTO.Card;

namespace MyWebBank.Application.DTO.Account
{
    public class AccountWithCardsDto : AccountDto
    {
        public IEnumerable<CardDto> Cards { get; set; }
    }
}
