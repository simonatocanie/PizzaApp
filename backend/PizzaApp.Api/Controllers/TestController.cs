using Microsoft.AspNetCore.Mvc;

namespace PizzaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestController> logger;

        public TestController(ILogger<TestController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "test1", "test2" };
        }
    }
}
