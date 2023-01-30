using cleanarchitecture.Application.Common.Errors;
using FluentResults;

namespace cleanarchitecture.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Result<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
        AuthenticationResult Login(string Email, string Password);
    }
}