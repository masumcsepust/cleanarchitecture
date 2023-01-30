using cleanarchitecture.Application.Common.Errors;
using cleanarchitecture.Application.Common.Interfaces.Authentication;
using cleanarchitecture.Application.Common.Interfaces.Persistence;
using cleanarchitecture.Domain.Common.Errors;
using cleanarchitecture.Domain.Entities;
using ErrorOr;

namespace cleanarchitecture.Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
public AuthenticationService(IJwtTokenGenerator iJwtTokenGenerator, IUserRepository iUserRepository)
    {
        _iJwtTokenGenerator = iJwtTokenGenerator;
        _iUserRepository = iUserRepository;
    }

    //public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // 1. valid the user doesn't exist
        if(_iUserRepository.GetUserByEmail(email) is not null) 
        {
            return Errors.User.DuplicateEmail;//Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
        }


        // 2. Create user (generate unique id) & Persist to DB
        var user = new User {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
        };

        _iUserRepository.Add(user);

        // create JWT token
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user exists
        if(_iUserRepository.GetUserByEmail(email) is not User user) 
        {
            return Errors.Authentication.InvalidCredential;
            //throw new System.Exception("user with given email does not exist.");
        }

        // 2. Validate the password is corrects
        if(user.Password != password) 
        {
            return new[] { Errors.Authentication.InvalidCredential };
            //throw new System.Exception("Invalid password");
        }
        
        // 3. create jwt token
        var token = _iJwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}