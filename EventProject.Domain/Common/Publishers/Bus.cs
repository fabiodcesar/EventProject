using EventProject.Domain.Common.Events;
using MediatR;

namespace EventProject.Domain.Common.Publishers
{
    public interface IBus
    {
        Task ThrowErrors(string[] errors);
    }

    public abstract class Bus : IBus
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
    }
}
