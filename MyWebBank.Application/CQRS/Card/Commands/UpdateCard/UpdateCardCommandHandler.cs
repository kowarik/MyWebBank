using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Card;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using MyWebBank.Application.Validators;

namespace MyWebBank.Application.CQRS.Card.Commands.UpdateCard
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, CardDto>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;

        public UpdateCardCommandHandler(ICardsRepository cardsRepository, IMapper mapper)
        {
            _cardsRepository = cardsRepository;
            _mapper = mapper;
        }
        public async Task<CardDto> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UpdateCardDtoValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (validationResult.Errors.Any())
                    throw new BadRequestException("Invalid Card", validationResult);

                var cardToUpdate = _mapper.Map<Domain.Entities.Card>(request);
                var updatedCard = await _cardsRepository.UpdateAsync(cardToUpdate);
                return _mapper.Map<CardDto>(updatedCard);
            }
            catch (BadRequestException)
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
