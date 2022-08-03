using MediatR;

namespace EventProject
{
    public class Event2 : Event
    {
        public Event2(Guid id) : base(id) { }
    }

    public class EventHandler2 : INotificationHandler<Event2>
    {
        private readonly ILogger<EventHandler2> _logger;
        private readonly IEventPublisher _publisher;
        public EventHandler2(ILogger<EventHandler2> logger, IEventPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Handle(Event2 event2, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler2).Name} [${event2.Id}]");
            await _publisher.PublishMessage3(event2.Id);
        }
    }
}