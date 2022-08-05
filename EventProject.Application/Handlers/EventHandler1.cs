using EventProject.Domain.Bus;
using EventProject.Domain.Common.Exceptions;
using EventProject.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventProject.Application.Handlers
{
    public sealed class EventHandler1 : EventHandlerBase, INotificationHandler<Event1>
    {
        private readonly ILogger<EventHandler1> _logger;
        private readonly IEventBus _bus;
        public EventHandler1(ILogger<EventHandler1> logger, IEventBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Handle(Event1 event1, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler1).Name} [${event1.Id}]");

            if (event1.Id.ToString() == "00000000-0000-0000-0000-000000000001")
            {
                throw new DomainException($"{typeof(EventHandler1).Name} Forbiden Guid [${event1.Id}]");
            }

            await _bus.Event2(event1.Id);
        }
    }
}
