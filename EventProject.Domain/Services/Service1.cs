using EventProject.Domain.Bus;
using EventProject.Domain.Common.Exceptions;
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
        private readonly IEventBus _bus;

        public Service1(ILogger<Service1> logger, IEventBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Invoke(Guid id, string parameter)
        {
            _logger.LogInformation($"{typeof(Service1).Name} [${id}]");

            if (string.IsNullOrEmpty(parameter))
            {
                throw new DomainException("The parameter is required");
            }

            await _bus.Event1(id);
        }
    }
}
