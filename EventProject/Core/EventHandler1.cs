using MediatR;

namespace EventProject
{
    public class Message1 : MessageBase
    {
        public Message1(Guid id) : base(id) { }
    }

    public class EventHandler1 : INotificationHandler<Message1>
    {
        private readonly ILogger<EventHandler1> _logger;
        private readonly IEventPublisher _publisher;
        public EventHandler1(ILogger<EventHandler1> logger, IEventPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Handle(Message1 message, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler1).Name} [${message.Id}]");
            await _publisher.PublishMessage2(message.Id);
        }
    }
}
