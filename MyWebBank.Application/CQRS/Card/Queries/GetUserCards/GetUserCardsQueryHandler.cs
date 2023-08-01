using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Card;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Card.Queries.GetUserCards
{
    public class GetUserCardsQueryHandler : IRequestHandler<GetUserCardsQuery, IEnumerable<CardDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        public GetUserCardsQueryHandler(IMapper mapper, ICardsRepository cardsRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
        }
        public async Task<IEnumerable<CardDto>> Handle(GetUserCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allUserCards = await _cardsRepository.GetUserCardsAsync();

                var allUserCardsDto = _mapper.Map<IEnumerable<CardDto>>(allUserCards);

                return allUserCardsDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
