using MediatR;

namespace EventProject
{
    public class Message2 : Message
    {
        public Message2(Guid id) : base(id) { }
    }

    public class EventHandler2 : INotificationHandler<Message2>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EventHandler1> _logger;
        public EventHandler2(IMediator mediator, ILogger<EventHandler1> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(Message2 message, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler2).Name} [${message.Id}]");
            await _mediator.Publish(new Message3(message.Id), cancellationToken);
        }
    }
}