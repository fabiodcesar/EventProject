using EventProject.Domain.Common.Exceptions;
using EventProject.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventProject.Application.Handlers
{
    public sealed class EventHandler3 : EventHandlerBase, INotificationHandler<Event3>
    {
        private readonly ILogger<EventHandler3> _logger;
        public EventHandler3(ILogger<EventHandler3> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Event3 event3, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler3).Name} [${event3.Id}]");
            if (event3.Id.ToString() == "00000000-0000-0000-0000-000000000003")
            {
                throw new DomainException($"{typeof(EventHandler3).Name} Forbiden Guid [${event3.Id}]");
            }
        }
    }
}