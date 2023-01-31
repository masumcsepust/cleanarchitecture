using cleanarchitecture.Application.Services.Authentication.Commands;
using cleanarchitecture.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace cleanarchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueriesService, AuthenticationQueriesService>();

            return services;
        }
    }
}