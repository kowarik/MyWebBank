using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Card;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using MyWebBank.Application.Validators;

namespace MyWebBank.Application.CQRS.Card.Commands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, CardDto>
    {
        private readonly IMapper _mapper;
        private readonly ICardsRepository _cardsRepository;

        public CreateCardCommandHandler(ICardsRepository cardsRepository, IMapper mapper)
        {
            _cardsRepository = cardsRepository;
            _mapper = mapper;
        }

        public async Task<CardDto> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateCardDtoValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (validationResult.Errors.Any())
                    throw new BadRequestException("Invalid Card", validationResult);

                var cardToCreate = _mapper.Map<Domain.Entities.Card>(request);
                var createdCard = await _cardsRepository.CreateAsync(cardToCreate);
                return _mapper.Map<CardDto>(createdCard);
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
