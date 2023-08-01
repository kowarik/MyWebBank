using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Card;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Card.Queries.GetCard
{
    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, CardDto>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;
        public GetCardQueryHandler(IMapper mapper, ICardsRepository cardsRepository)
        {
            _mapper = mapper;
            _cardsRepository = cardsRepository;
        }
        public async Task<CardDto> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var card = await _cardsRepository.GetByIdAsync(request.Id);
                var cardDto = _mapper.Map<CardDto>(card);

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
