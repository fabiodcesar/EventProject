using MediatR;

namespace EventProject
{
    public class Message1 : MessageBase
    {
        public Message1(Guid id) : base(id) { }
    }

    public class EventHandler1 : INotificationHandler<Message1>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EventHandler1> _logger;
        public EventHandler1(IMediator mediator, ILogger<EventHandler1> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(Message1 message, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{typeof(EventHandler1).Name} [${message.Id}]");
            await _mediator.Publish(new Message2(message.Id), cancellationToken);
        }
    }
}
