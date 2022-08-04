using EventProject.Domain.Events;
using EventProject.Domain.Publishers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventProject.Application.Handlers
{
    public sealed class EventHandler1 : EventHandlerBase, INotificationHandler<Event1>
    {
        private readonly ILogger<EventHandler1> _logger;
        private readonly IBus _bus;
        public EventHandler1(ILogger<EventHandler1> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Handle(Event1 event1, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler1).Name} [${event1.Id}]");
            await _bus.Message2(event1.Id);
        }
    }
}
