using MediatR;

namespace EventProject
{
    public class Message3 : MessageBase
    {
        public Message3(Guid id) : base(id) { }
    }

    public class EventHandler3 : INotificationHandler<Message3>
    {
        private readonly ILogger<EventHandler3> _logger;
        public EventHandler3(ILogger<EventHandler3> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Message3 message, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler3).Name} [${message.Id}]");
        }
    }
}