namespace EventProject
{
    public interface IService1
    {
        Task Invoke(Guid id, string parameter);
    }

    public class Service1 : IService1
    {
        private readonly ILogger<Service1> _logger;
        private readonly IEventPublisher _publisher;

        public Service1(ILogger<Service1> logger, IEventPublisher publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Invoke(Guid id, string parameter)
        {
            _logger.LogInformation($"{typeof(Service1).Name} [${id}]");

            if (string.IsNullOrEmpty(parameter))
            {
                await _publisher.PublishErrors(new string[] { "The parameter is required" });
                return;
            }

            await _publisher.PublishMessage1(id);
        }
    }
}
