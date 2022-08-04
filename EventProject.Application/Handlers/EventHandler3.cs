using EventProject.Domain.Events;
using EventProject.Domain.Publishers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventProject.Application.Handlers
{
    public sealed class EventHandler3 : EventHandlerBase, INotificationHandler<Event3>
    {
        private readonly ILogger<EventHandler3> _logger;
        private readonly IBus _bus;
        public EventHandler3(ILogger<EventHandler3> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Handle(Event3 event3, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler3).Name} [${event3.Id}]");
        }
    }
}