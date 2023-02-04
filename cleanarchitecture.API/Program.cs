using cleanarchitecture.Application;
using cleanarchitecture.Infrastructure;
using cleanarchitecture.API.Filters;
using cleanarchitecture.API.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using cleanarchitecture.API;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    //builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

    //builder.Services.AddSingleton<ProblemDetailsFactory, CleanArchitectureProblemDetailsFactory>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    //app.UseMiddleware<ErrorHandlingMiddleWare>();
    app.UseExceptionHandler("/error");
    
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
