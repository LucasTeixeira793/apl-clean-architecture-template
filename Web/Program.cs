using CleanArchitecture.API.Configuration;
using CleanArchitecture.Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

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
