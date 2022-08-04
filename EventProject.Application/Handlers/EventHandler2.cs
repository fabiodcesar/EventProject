using EventProject.Domain.Common.Exceptions;
using EventProject.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventProject.Application.Handlers
{
    public sealed class EventHandler2 : EventHandlerBase, INotificationHandler<Event2>
    {
        private readonly ILogger<EventHandler2> _logger;
        private readonly Domain.Publishers.IPublisher _publisher;
        public EventHandler2(ILogger<EventHandler2> logger, Domain.Publishers.IPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Handle(Event2 event2, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler2).Name} [${event2.Id}]");

            if (event2.Id.ToString() == "00000000-0000-0000-0000-000000000002")
            {
                throw new DomainException($"{typeof(EventHandler2).Name} Forbiden Guid [${event2.Id}]");
            }

            await _publisher.Event3(event2.Id);
        }
    }
}