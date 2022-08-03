using MediatR;

namespace EventProject
{
    public class Event3 : Event
    {
        public Event3(Guid id) : base(id) { }
    }

    public class EventHandler3 : INotificationHandler<Event3>
    {
        private readonly ILogger<EventHandler3> _logger;
        public EventHandler3(ILogger<EventHandler3> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Event3 event3, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler3).Name} [${event3.Id}]");
        }
    }
}