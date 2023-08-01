using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Account;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;
using MyWebBank.Application.Validators;

namespace MyWebBank.Application.CQRS.Account.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountDto>
    {
        private readonly IMapper _mapper;
        private readonly IAccountsRepository _accountsRepository;
        public CreateAccountCommandHandler(IMapper mapper, IAccountsRepository accountsRepository)
        {
            _mapper = mapper;
            _accountsRepository = accountsRepository;
        }
        public async Task<AccountDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var accountDto = new AccountDto();
                accountDto.AppUserId = request.AppUserId;
                var createdAccount = await _accountsRepository.CreateAsync(_mapper.Map<Domain.Entities.Account>(accountDto));
                var createdAccountDto = _mapper.Map<AccountDto>(createdAccount);

                return createdAccountDto;
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
