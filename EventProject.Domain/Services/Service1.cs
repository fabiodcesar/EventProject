using EventProject.Domain.Publishers;
using Microsoft.Extensions.Logging;

namespace EventProject.Domain.Services
{
    public interface IService1
    {
        Task Invoke(Guid id, string parameter);
    }

    public sealed class Service1 : IService1
    {
        private readonly ILogger<Service1> _logger;
        private readonly IPublisher1 _publisher;

        public Service1(ILogger<Service1> logger, IPublisher1 publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Invoke(Guid id, string parameter)
        {
            _logger.LogInformation($"{typeof(Service1).Name} [${id}]");

            if (string.IsNullOrEmpty(parameter))
            {
                await _publisher.ThrowErrors(new string[] { "The parameter is required" });
                return;
            }

            await _publisher.Message1(id);
        }
    }
}
