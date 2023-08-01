using MediatR;
using MyWebBank.Application.Exceptions;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Application.CQRS.Account.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, bool>
    {
        private readonly IAccountsRepository _accountsRepository;

        public DeleteAccountCommandHandler(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isDeleted = await _accountsRepository.DeleteAsync(request.Id);

                return isDeleted;
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
