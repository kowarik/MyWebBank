using AutoMapper;
using MediatR;
using MyWebBank.Application.DTO.Account;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Account.Queries.GetAccountWithCards
{
    public class GetAccountWithCardsQueryHandler : IRequestHandler<GetAccountWithCardsQuery, AccountWithCardsDto>
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IMapper _mapper;
        public GetAccountWithCardsQueryHandler(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<AccountWithCardsDto> Handle(GetAccountWithCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _accountsRepository.GetAccountWithCardsAsync(request.Id);
                return _mapper.Map<AccountWithCardsDto>(account);
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
