using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost()]
        public async Task<IActionResult> UpdateQuantity(ProductModel dto)
        {
            var result = await _inventoryService.UpdateQuantity(dto.Id, dto.Quantity);
            return Ok(result);
        }
    }

    public interface IInventoryService
    {
        Task<bool> UpdateQuantity(Guid id, int quantity);
    }

    public class InventoryService : IInventoryService
    {
        private readonly ILogger<InventoryService> _logger;
        private readonly IMediator _mediator;

        public InventoryService(ILogger<InventoryService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<bool> UpdateQuantity(Guid id, int quantity)
        {
            _logger.LogInformation("InventoryService.DecreateQuantity");
            if (quantity <= 10)
            {
                await _mediator.Publish(new LowStockEvent(id, quantity));
            }
            return true;
        }
    }

    public class LowStockEvent : INotification
    {
        public Guid Id { get; private set; }
        public int Quantity { get; private set; }

        public LowStockEvent(Guid id, int remaningQuantity)
        {
            Id = id;
            Quantity = remaningQuantity;
        }
    }

    public class LowStockEventHandler : INotificationHandler<LowStockEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LowStockEventHandler> _logger;
        public LowStockEventHandler(IMediator mediator, ILogger<LowStockEventHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(LowStockEvent message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("LowStockEventHandler [" + message.Id.ToString() + "]");

            if (message.Quantity <= 5)
            {
                await _mediator.Publish(new AutofillfillEvent(message.Id, message.Quantity), cancellationToken);
            }
        }
    }

    public class AutofillfillEvent : INotification
    {
        public AutofillfillEvent(Guid id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public int Quantity { get; private set; }
    }

    public class AutofulfillEventHandler : INotificationHandler<AutofillfillEvent>
    {
        private readonly ILogger<AutofulfillEventHandler> _logger;
        public AutofulfillEventHandler(ILogger<AutofulfillEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(AutofillfillEvent message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("AutofillStockEventHandler [" + message.Id.ToString() + "]");
        }
    }
}