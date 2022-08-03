using MediatR;

namespace EventProject
{
    public interface IService1
    {
        Task Invoke(Guid id, string parameter);
    }

    public class Service1 : IService1
    {
        private readonly ILogger<Service1> _logger;
        private readonly IMediatorHandler _mediator;

        public Service1(ILogger<Service1> logger, IMediatorHandler mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Invoke(Guid id, string parameter)
        {
            _logger.LogInformation($"{typeof(Service1).Name} [${id}]");

            if (string.IsNullOrEmpty(parameter))
            {
                await _mediator.Publish(new ErrorEvent(new string[] { "The parameter is required" }));
                return;
            }

            await _mediator.Publish(new Message1(id));
        }
    }
}
