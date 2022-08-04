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
        private readonly IBus _bus;

        public Service1(ILogger<Service1> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Invoke(Guid id, string parameter)
        {
            _logger.LogInformation($"{typeof(Service1).Name} [${id}]");

            if (string.IsNullOrEmpty(parameter))
            {
                await _bus.ThrowErrors(new string[] { "The parameter is required" });
                return;
            }

            await _bus.Message1(id);
        }
    }
}
