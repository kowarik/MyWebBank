using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Transaction;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Transaction.Queries.GetAllTransactions
{
    public class GetAllTransactionQueryHandler : IRequestHandler<GetAllTransactionQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IMapper _mapper;
        public GetAllTransactionQueryHandler(ITransactionsRepository transactionsRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transaction = await _transactionsRepository.GetUserTransactionsAsync();
                return _mapper.Map<IEnumerable<TransactionDto>>(transaction);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
