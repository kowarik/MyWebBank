using AutoMapper;
using MyWebBank.Application.DTO.Account;
using MyWebBank.Application.DTO.Card;
using MyWebBank.Application.DTO.Transaction;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Application.MappingProfiles
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Card, CardDto>().ReverseMap();
            CreateMap<Card, CardWithTransactionsDto>().ReverseMap();
            CreateMap<Card, CreateCardDto>().ReverseMap();
            CreateMap<Card, UpdateCardDto>().ReverseMap();

            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, MakeTransactionDto>().ReverseMap();
            CreateMap<Transaction, TransactionWithCardsDto>().ReverseMap();

            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, AccountWithCardsDto>().ReverseMap();
        }
    }
}
