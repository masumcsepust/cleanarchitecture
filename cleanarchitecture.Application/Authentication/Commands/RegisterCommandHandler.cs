
using cleanarchitecture.Application.Services.Authentication.Common;
using MediatR;
using ErrorOr;
using cleanarchitecture.Application.Common.Interfaces.Persistence;
using cleanarchitecture.Application.Common.Interfaces.Authentication;
using cleanarchitecture.Domain.Entities;
using cleanarchitecture.Domain.Common.Errors;

namespace cleanarchitecture.Application.Authentication.Commands;

public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _iUserRepository;
public RegisterCommandHandler(IJwtTokenGenerator iJwtTokenGenerator, IUserRepository iUserRepository)
    {
        _iJwtTokenGenerator = iJwtTokenGenerator;
        _iUserRepository = iUserRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. valid the user doesn't exist
        if(_iUserRepository.GetUserByEmail(command.Email) is not null) 
        {
            return Errors.User.DuplicateEmail;//Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
        }


        // 2. Create user (generate unique id) & Persist to DB
        var user = new User {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
        };

        _iUserRepository.Add(user);

        // create JWT token
        var token = _iJwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }
}