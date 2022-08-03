using Microsoft.AspNetCore.Mvc;

namespace EventProject.Controllers
{
    public class Model
    {
        public Guid Id { get; set; }
        public string Parameter { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IService1 _service1;
        public TestController(IService1 service1)
        {
            _service1 = service1;
        }

        [HttpPost()]
        public async Task<IActionResult> UpdateQuantity(Model model)
        {
            await _service1.Invoke(model.Id, model.Parameter);
            return Ok();
        }
    }
}