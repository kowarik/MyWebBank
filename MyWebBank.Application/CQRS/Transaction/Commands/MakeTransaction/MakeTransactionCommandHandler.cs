using AutoMapper;
using FluentValidation;
using MediatR;
using MyWebBank.Application.DTO.Transaction;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using MyWebBank.Application.Validators;

namespace MyWebBank.Application.CQRS.Transaction.Commands.MakeTransaction
{
    public class MakeTransactionCommandHandler : IRequestHandler<MakeTransactionCommand, TransactionDto>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionsRepository _transactionsRepository;

        public MakeTransactionCommandHandler(IMapper mapper, ITransactionsRepository transactionsRepository)
        {
            _mapper = mapper;
            _transactionsRepository = transactionsRepository;
        }

        public async Task<TransactionDto> Handle(MakeTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new MakeTransactionDtoValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (validationResult.Errors.Any())
                    throw new BadRequestException("Invalid Card", validationResult);

                var transaction = _mapper.Map<Domain.Entities.Transaction>(request);
                var resultTransaction = await _transactionsRepository.MakeTransactionAsync(transaction);

                var resultTransactionDto = _mapper.Map<TransactionDto>(resultTransaction);

                return resultTransactionDto;
            }
            catch (EntityNotFoundException)
            {
                throw;
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
