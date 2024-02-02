using Microsoft.AspNetCore.Mvc;
using PizzaApp.BusinessLogic.Models.Products;
using PizzaApp.BusinessLogic.Services.Contracts;

namespace PizzaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private readonly IProductsService productService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await productService.GetAllProducts();

            return Ok(products);

        }
    }
}
