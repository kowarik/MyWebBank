using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Card;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Card.Queries.GetCardWithTransactions
{
    public class GetCardWithTransactionsQueryHandler : IRequestHandler<GetCardWithTransactionsQuery, CardWithTransactionsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        public GetCardWithTransactionsQueryHandler(IMapper mapper, ICardsRepository cardsRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
        }
        public async Task<CardWithTransactionsDto> Handle(GetCardWithTransactionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var card = await _cardsRepository.GetCardWithTransactionsAsync(request.Id);
                var cardDto = _mapper.Map<CardWithTransactionsDto>(card);

                return cardDto;
            }
            catch (EntityNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
