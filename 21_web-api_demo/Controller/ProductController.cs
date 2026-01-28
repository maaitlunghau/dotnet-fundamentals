using _21_web_api_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _21_web_api_demo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public ProductController(DataContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                // return Ok(product);
                return Created("", product);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product is null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest("Product ID mismatch");

            var existingProduct = await _dbContext.Products.FindAsync(id);
            if (existingProduct is null) return NotFound();

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _dbContext.SaveChangesAsync();
            return Ok(existingProduct);
        }
    }
}
