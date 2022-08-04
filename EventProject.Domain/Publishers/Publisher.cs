using EventProject.Domain.Common.Events;
using EventProject.Domain.Events;
using MediatR;

namespace EventProject.Domain.Publishers
{
    public interface IPublisher
    {
        Task Event1(Guid id);
        Task Event2(Guid id);
        Task Event3(Guid id);
        Task ThrowErrors(string[] errors);
    }

    public class Publisher : IPublisher
    {
        protected readonly IMediator _mediator;
        public Publisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ThrowErrors(string[] errors)
        {
            await _mediator.Publish(new ErrorEvent(errors));
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
