

using cleanarchitecture.Application.Common.Interfaces.Authentication;
using cleanarchitecture.Application.Common.Interfaces.Persistence;
using cleanarchitecture.Application.Services.Authentication.Common;
using cleanarchitecture.Domain.Common.Errors;
using cleanarchitecture.Domain.Entities;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Application.Authentication.Queries;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
    public LoginQueryHandler(IJwtTokenGenerator iJwtTokenGenerator, IUserRepository iUserRepository)
        {
            _iJwtTokenGenerator = iJwtTokenGenerator;
            _iUserRepository = iUserRepository;
        }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if(_iUserRepository.GetUserByEmail(query.Email) is not User user) 
        {
            return Errors.Authentication.InvalidCredential;
            //throw new System.Exception("user with given email does not exist.");
        }

        // 2. Validate the password is corrects
        if(user.Password != query.Password) 
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