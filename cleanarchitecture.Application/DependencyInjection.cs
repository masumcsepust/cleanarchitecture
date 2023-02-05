
using System.Reflection;
using cleanarchitecture.Application.Authentication.Commands;
using cleanarchitecture.Application.Common.Behaviors;
using cleanarchitecture.Application.Services.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace cleanarchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            // services.AddScoped<IAuthenticationQueriesService, AuthenticationQueriesService>();
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            services.AddScoped(
                typeof(IPipelineBehavior<,>), 
                typeof(ValidationBehavior<,>));

            // services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            //  ValidationBehavior>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();

            return services;
        }
    }
}