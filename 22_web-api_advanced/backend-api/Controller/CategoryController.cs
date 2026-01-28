using backend_api.DTOs;
using backend_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _dbContext;
        public CategoryController(DataContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryCreateDto category)
        {
            var entity = new Category
            {
                Name = category.Name
            };

            await _dbContext.Categories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return Created("", category);
        }
    }
}
