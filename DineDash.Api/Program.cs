using DineDash.Application;
using DineDash.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
}

var app = builder.Build();


{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run("http://localhost:5000");
}
