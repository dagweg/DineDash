using DineDash.Application;
using DineDash.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();


{
    app.MapControllers();
    app.Run("http://localhost:5000");
}
