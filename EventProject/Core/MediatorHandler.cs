using MediatR;

namespace EventProject
{
    public interface IMediatorHandler
    {
        Task Publish<T>(T eventToPublish) where T : Message;
    }

    /// <summary>
    /// Wraps MediatR 
    /// </summary>
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<T>(T evento) where T : Message
        {
            await _mediator.Publish(evento);
        }
    }
}
