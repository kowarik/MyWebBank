using MediatR;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Card.Commands.DeleteCard
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, bool>
    {
        private readonly ICardsRepository _cardsRepository;
        public DeleteCardCommandHandler(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }
        public async Task<bool> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cardToDelete = await _cardsRepository.GetByIdAsync(request.Id);

                return await _cardsRepository.DeleteAsync(cardToDelete.Id);
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
