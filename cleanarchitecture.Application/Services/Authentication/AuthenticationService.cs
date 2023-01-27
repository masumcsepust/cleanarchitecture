using cleanarchitecture.Application.Common.Interfaces.Authentication;

namespace cleanarchitecture.Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;

public AuthenticationService(IJwtTokenGenerator iJwtTokenGenerator)
    {
        _iJwtTokenGenerator = iJwtTokenGenerator;
    }
    

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        // check if user already exists

        // Create user (generate unique id)

        // create JWT token
        Guid userId = Guid.NewGuid();
        var token = _iJwtTokenGenerator.GenerateToken(userId, FirstName, LastName);
        return new AuthenticationResult(
            Guid.NewGuid(),
            FirstName,
            LastName,
            Email,
            token
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