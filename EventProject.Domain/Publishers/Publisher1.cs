using EventProject.Domain.Common.Publishers;
using EventProject.Domain.Events;
using MediatR;

namespace EventProject.Domain.Publishers
{
    public interface IPublisher1: Common.Publishers.IPublisher
    {
        Task Message1(Guid id);
        Task Message2(Guid id);
        Task Message3(Guid id);
    }

    public sealed class Publisher1 : Publisher, IPublisher1
    {
        public Publisher1(IMediator mediator) : base(mediator) { }

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
