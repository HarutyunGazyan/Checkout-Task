using Checkout.Services;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProductFacadeAsync();

            if (products?.Any() == true)
            {
                return Ok(products);
            }

            return NoContent();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            var product = await _productService.GetAsync(productId);

            if (product == null)
            {
                return NoContent();
            }

            return Ok(product);
        }
    }
}
