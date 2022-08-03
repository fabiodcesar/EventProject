using MediatR;

namespace EventProject
{
    public class Message2 : MessageBase
    {
        public Message2(Guid id) : base(id) { }
    }

    public class EventHandler2 : INotificationHandler<Message2>
    {
        private readonly ILogger<EventHandler2> _logger;
        private readonly IEventPublisher _publisher;
        public EventHandler2(ILogger<EventHandler2> logger, IEventPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Handle(Message2 message, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler2).Name} [${message.Id}]");
            await _publisher.PublishMessage3(message.Id);
        }
    }
}