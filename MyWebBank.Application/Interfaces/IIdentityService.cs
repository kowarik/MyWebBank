using Microsoft.AspNetCore.Identity;
using MyWebBank.Application.DTO;

namespace MyWebBank.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<SignInResult> SignInAsync(SignInDto signInDto);
        Task<IdentityResult> SignUpAsync(SignUpDto signUpDto);
        Task SignOutAsync();
        Task<string?> GetUserNameAsync(Guid userId);
        Task<IdentityResult> DeleteUserAsync(Guid userId);
    }
}
