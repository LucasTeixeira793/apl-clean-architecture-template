using CleanArchitecture.Application;
using Serilog;
using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

# region [ Arquitetura ]
builder.Services.AddApplication();
#endregion

builder.Services.AddOpenApi();

builder.Services.AddConectionServices(builder.Configuration);

builder.Services.AddSwaggerConfig();

builder.Services.AddDependencyInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
