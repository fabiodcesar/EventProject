using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("raise")]
        public IActionResult RaiseEvent()
        {
            _logger.LogInformation("Event raised");
            return Ok("000875");
        }
    }
}