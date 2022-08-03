using MediatR;

namespace EventProject
{
    public interface IMediatorHandler
    {
        Task Publish<T>(T eventToPublish) where T : MessageBase;
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

        public async Task Publish<T>(T evento) where T : MessageBase
        {
            await _mediator.Publish(evento);
        }
    }
}
