using EventProject.Domain.Publishers;
using EventProject.Domain.Services;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IPublisher1, Publisher1>();

// Register the service
builder.Services.AddScoped<IService1, Service1>();

//Scans for all handlers
builder.Services.AddMediatR(typeof(EventProject.Application.Handlers.EventHandler));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
