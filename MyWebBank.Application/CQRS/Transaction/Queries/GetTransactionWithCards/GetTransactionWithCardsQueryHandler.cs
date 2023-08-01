using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Transaction;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Transaction.Queries.GetTransactionWithCards
{
    public class GetTransactionWithCardsQueryHandler : IRequestHandler<GetTransactionWithCardsQuery, TransactionWithCardsDto>
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IMapper _mapper;

        public GetTransactionWithCardsQueryHandler(ITransactionsRepository transactionsRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;
        }

        public async Task<TransactionWithCardsDto> Handle(GetTransactionWithCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transaction = await _transactionsRepository.GetTransactiontWithCardsAsync(request.Id);
                return _mapper.Map<TransactionWithCardsDto>(transaction);
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
