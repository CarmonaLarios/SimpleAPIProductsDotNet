using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleAPIProducts.Services;

namespace SimpleAPIProducts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var item = _productService.FindById(id);

            if (item == null) return NoContent();

            return Ok(_productService.FindById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _productService.Delete(id);

            if (item == null) return NotFound();
         
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null) return BadRequest();
            return Ok(_productService.Create(product));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (product == null) return BadRequest();
            return Ok(_productService.Update(product));
        }
    }
}
