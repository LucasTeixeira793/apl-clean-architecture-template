using CleanArchitecture.API.Configuration;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

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
