using EventProject.Domain.Events;
using EventProject.Domain.Publishers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventProject.Application.Handlers
{
    public sealed class EventHandler2 : EventHandlerBase, INotificationHandler<Event2>
    {
        private readonly ILogger<EventHandler2> _logger;
        private readonly IBus _bus;
        public EventHandler2(ILogger<EventHandler2> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Handle(Event2 event2, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler2).Name} [${event2.Id}]");
            await _bus.Message3(event2.Id);
        }
    }
}