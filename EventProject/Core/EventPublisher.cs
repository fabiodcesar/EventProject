using MediatR;

namespace EventProject
{    
    public interface IEventPublisher
    {
        Task PublishMessage1(Guid id);
        Task PublishMessage2(Guid id);
        Task PublishMessage3(Guid id);
        Task PublishErrors(string[] errors);
    }

    public class EventPublisher : IEventPublisher
    {
        private readonly IMediator _mediator;

        public EventPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishMessage1(Guid id)
        {
            await _mediator.Publish(new Event1(id));
        }

        public async Task PublishMessage2(Guid id)
        {
            await _mediator.Publish(new Event2(id));
        }

        public async Task PublishMessage3(Guid id)
        {
            await _mediator.Publish(new Event3(id));
        }

        public async Task PublishErrors(string[] errors)
        {
            await _mediator.Publish(new ErrorEvent(errors));
        }
    }
}
