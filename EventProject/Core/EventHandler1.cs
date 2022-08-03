using MediatR;

namespace EventProject
{
    public class Event1 : Event
    {
        public Event1(Guid id) : base(id) { }
    }

    public class EventHandler1 : INotificationHandler<Event1>
    {
        private readonly ILogger<EventHandler1> _logger;
        private readonly IEventPublisher _publisher;
        public EventHandler1(ILogger<EventHandler1> logger, IEventPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Handle(Event1 event1, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler1).Name} [${event1.Id}]");
            await _publisher.PublishMessage2(event1.Id);
        }
    }
}
