using EventProject.Domain.Bus;
using EventProject.Domain.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IEventBus, EventBus>();

// Register the service
builder.Services.AddScoped<IService1, Service1>();

//Scans for all handlers
builder.Services.AddMediatR(typeof(EventProject.Application.Handlers.EventHandlerBase));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
