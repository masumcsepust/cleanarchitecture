
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

            return services;
        }
    }
}