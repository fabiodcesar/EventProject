namespace EventProject
{
    public interface IService1
    {
        Task<bool> Invoke(Guid id);
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

        public async Task<bool> Invoke(Guid id)
        {
            _logger.LogInformation($"{typeof(Service1).Name} [${id}]");
            await _mediator.Publish(new Message1(id));
            return true;
        }
    }
}
