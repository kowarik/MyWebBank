using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyWebBank.Application.CQRS.Account.Commands.CreateAccount;
using MyWebBank.Application.DTO;
using MyWebBank.Application.Interfaces;

namespace MyWebBank.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMediator _mediator;
        public IdentityService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mediator = mediator;
        }

        public async Task<SignInResult> SignInAsync(SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.Email, signInDto.Password, signInDto.RememberMe, lockoutOnFailure: false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDto signUpDto)
        {
            if (await _userManager.FindByEmailAsync(signUpDto.Email) == null)
            {
                var user = new AppUser
                {
                    Email = signUpDto.Email,
                    UserName = signUpDto.Email
                };
                var result = await _userManager.CreateAsync(user, signUpDto.Password);

                if (!await _roleManager.RoleExistsAsync(signUpDto.Role))
                {
                    var role = new AppRole { Name = signUpDto.Role };
                    var roleAddResult = await _roleManager.CreateAsync(role);
                    if (!roleAddResult.Succeeded)
                    {
                        return IdentityResult.Failed(new IdentityError { Description = "Failed to create User Role" });
                    }
                }

                var addUserRoleResult = await _userManager.AddToRoleAsync(user, signUpDto.Role);
                if (!addUserRoleResult.Succeeded)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Failed to create User with this Role" });
                }

                if (result.Succeeded)
                {
                    var account = await _mediator.Send(new CreateAccountCommand(user.Id));
                    user.UserAccountId = account.AppUserId;

                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                return result;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "User already registered" });
            }
        }

        public async Task<IdentityResult> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

            return await _userManager.DeleteAsync(user);
        }

        public async Task<string?> GetUserNameAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user?.UserName;
        }
    }
}