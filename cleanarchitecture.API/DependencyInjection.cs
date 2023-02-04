using cleanarchitecture.API.Common.Errors;
using cleanarchitecture.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace cleanarchitecture.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CleanArchitectureProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}