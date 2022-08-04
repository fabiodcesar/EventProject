using EventProject.Domain.Common.Events;
using EventProject.Domain.Events;
using MediatR;

namespace EventProject.Domain.Publishers
{
    public interface IBus
    {
        Task Message1(Guid id);
        Task Message2(Guid id);
        Task Message3(Guid id);
        Task ThrowErrors(string[] errors);
    }

    public class Bus : IBus
    {
        protected readonly IMediator _mediator;
        public Bus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ThrowErrors(string[] errors)
        {
            await _mediator.Publish(new ErrorEvent(errors));
        }

        public async Task Message1(Guid id)
        {
            await _mediator.Publish(new Event1(id));
        }

        public async Task Message2(Guid id)
        {
            await _mediator.Publish(new Event2(id));
        }

        public async Task Message3(Guid id)
        {
            await _mediator.Publish(new Event3(id));
        }
    }
}
