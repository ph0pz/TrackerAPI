using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrackerAPI.Services.Interfaces;
using TrackerData;

namespace TrackerAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryInterface _categoryService;

        public CategoryController(CategoryInterface categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            var categories = await _categoryService.GetAllCategory();
            return Ok(categories);
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult<Category>> AddCategory([FromBody] Category category)
        {
            var addedCategory = await _categoryService.AddCategory(category);

            if (addedCategory == null)
            {
                return BadRequest("Failed to add category.");
            }

            return Ok(addedCategory);
        }

        [HttpPut("EditCategory")]
        public async Task<ActionResult<Category>> EditCategory([FromBody] Category category)
        {
            var editedCategory = await _categoryService.EditCategory(category);

            if (editedCategory == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(editedCategory);
        }

        [HttpDelete("DeleteCategory/{categoryId}")]
        public async Task<ActionResult<Category>> DeleteCategory(int categoryId)
        {
            var deletedCategory = await _categoryService.DeleteCategory(categoryId);

            if (deletedCategory == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(deletedCategory);
        }
    }
}
