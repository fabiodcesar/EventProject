using EventProject.Domain.Events;
using MediatR;

namespace EventProject.Domain.Bus
{
    public interface IEventBus
    {
        Task Event1(Guid id);
        Task Event2(Guid id);
        Task Event3(Guid id);
    }

    public class EventBus : IEventBus
    {
        protected readonly IMediator _mediator;
        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Event1(Guid id)
        {
            await _mediator.Publish(new Event1(id));
        }

        public async Task Event2(Guid id)
        {
            await _mediator.Publish(new Event2(id));
        }

        public async Task Event3(Guid id)
        {
            await _mediator.Publish(new Event3(id));
        }
    }
}
