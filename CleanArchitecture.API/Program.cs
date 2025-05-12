using CleanArchitecture.API.Configuration;
using CleanArchitecture.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var a = typeof(AssemblyReference).Assembly;
builder.Services.AddControllers()
    .AddApplicationPart(a);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddConectionServices(builder.Configuration);

builder.Services.AddSwaggerConfig();

builder.Services.AddDependencyInjection();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
