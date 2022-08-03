using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IInventoryService _inventoryService;
        public TestController(ILogger<TestController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("raise")]
        public async Task<IActionResult> RaiseEvent()
        {
            var result = await _inventoryService.DecreateQuantity(Guid.NewGuid(), 1);
            return Ok(result);
        }
    }

    public interface IInventoryService
    {
        Task<bool> DecreateQuantity(Guid id, int quantity);
    }

    public class InventoryService : IInventoryService
    {

        private readonly IMediatrHandler _bus;

        public InventoryService(IMediatrHandler bus)
        {
            _bus = bus;
        }

        public async Task<bool> DecreateQuantity(Guid id, int quantity)
        {
            await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(id, quantity));
            return await Task.FromResult(true);
        }
    }

    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }

        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }

    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly ILogger<ProdutoEventHandler> _logger;
        public ProdutoEventHandler(ILogger<ProdutoEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ProdutoEventHandler");
        }
    }

    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }

    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }

    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }

    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }


}