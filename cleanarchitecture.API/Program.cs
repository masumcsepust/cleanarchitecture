using cleanarchitecture.Application;
using cleanarchitecture.Infrastructure;
using cleanarchitecture.API.Filters;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
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
