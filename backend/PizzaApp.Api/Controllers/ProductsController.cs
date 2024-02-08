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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await productService.GetAllProductsAsync();

            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
            {
                logger.LogWarning("Product not found.");
                return NotFound();
            }

            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductCreatedDto createdPoduct)
        {
            var productDto = await productService.AddProductAsync(createdPoduct);

            if (productDto == null)
            {
                return BadRequest($"There was an unexpected exception when saving to database for product {createdPoduct.Name}.");
            }

            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateddDto updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                logger.LogWarning("The product with the id send does not match.");
                return BadRequest("The product with the id send does not match.");
            }

            var isSaved = await productService.UpdateProductAsync(updatedProduct); //see if need it the return type
            if (isSaved == null)
            {
                logger.LogWarning("Product not found.");
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await productService.DeleteProductAsync(id);
            if (isDeleted == null)
            {
                logger.LogWarning("Product not found.");
                return NotFound();
            }

            return NoContent();
        }
    }
}
