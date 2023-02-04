
using cleanarchitecture.Application.Authentication.Commands;
using cleanarchitecture.Application.Authentication.Queries;
using cleanarchitecture.Application.Services.Authentication.Common;
using cleanarchitecture.Contracts.Authentication;
using Mapster;

namespace cleanarchitecture.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.user);
    }
}