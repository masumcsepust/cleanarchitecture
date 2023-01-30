using cleanarchitecture.Application.Common.Errors;
using OneOf;

namespace cleanarchitecture.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        OneOf<AuthenticationResult, DuplicateEmailError> Register(string FirstName, string LastName, string Email, string Password);
        AuthenticationResult Login(string Email, string Password);
    }
}