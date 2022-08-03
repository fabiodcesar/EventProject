using EventProject;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IEventPublisher, EventPublisher>();

// Register the service
builder.Services.AddScoped<IService1, Service1>();

//Scans for all handlers, then you don't have to register every handler in the container
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
