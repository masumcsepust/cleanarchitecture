using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cleanarchitecture.Application.Services.Authentication
{
    public class AuthenticationService: IAuthenticationService
    {
        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                FirstName,
                LastName,
                Email,
                "token"
            );
        }

        public AuthenticationResult Login(string Email, string Password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "Masum",
                "Billah",
                Email,
                "token"
            );
        }
    }
}