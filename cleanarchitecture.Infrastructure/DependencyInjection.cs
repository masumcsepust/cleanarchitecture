using cleanarchitecture.Application.Common.Interfaces.Authentication;
using cleanarchitecture.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using cleanarchitecture.Application.Common.Interfaces.Services;
using cleanarchitecture.Infrastructure.Services;
using cleanarchitecture.Application.Common.Interfaces.Persistence;
using cleanarchitecture.Infrastructure.Persistence;

namespace cleanarchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}