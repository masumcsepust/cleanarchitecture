using cleanarchitecture.Application.Services.Authentication.Common;
using ErrorOr;

namespace cleanarchitecture.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        //Result<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
        ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
    }
}