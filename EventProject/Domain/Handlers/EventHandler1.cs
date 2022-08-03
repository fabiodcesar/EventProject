using EventProject.Core.Events;
using EventProject.Core.Publishers;
using MediatR;

namespace EventProject.Core.Handlers
{
    public sealed class EventHandler1 : INotificationHandler<Event1>
    {
        private readonly ILogger<EventHandler1> _logger;
        private readonly IPublisher1 _publisher;
        public EventHandler1(ILogger<EventHandler1> logger, IPublisher1 publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Handle(Event1 event1, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler1).Name} [${event1.Id}]");
            await _publisher.Message2(event1.Id);
        }
    }
}
