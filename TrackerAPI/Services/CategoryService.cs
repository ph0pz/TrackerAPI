using TrackerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TrackerData;

namespace TrackerAPI.Services
{
    public class CategoryService : CategoryInterface
    {
        private readonly TrackerDbContext _dbContext;

        public CategoryService(TrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddCategory(Category category)
        {
            // Add the category to the database
            category.CategoryColor = GenerateRandomColor();
            _dbContext.Categories.Add(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }
        private string GenerateRandomColor()
        {
            Random random = new Random();
            int red = random.Next(256);     // Generate random value for red component (0 - 255)
            int green = random.Next(256);   // Generate random value for green component (0 - 255)
            int blue = random.Next(256);    // Generate random value for blue component (0 - 255)

            string hexColor = $"#{red:X2}{green:X2}{blue:X2}"; // Convert RGB to hexadecimal

            return hexColor;
        }

        public async Task<Category> DeleteCategory(int categoryId)
        {
            // Find the category by ID
            var categoryToDelete = await _dbContext.Categories.FindAsync(categoryId);

            if (categoryToDelete == null)
            {
                // Handle the case where the category is not found
                return null;
            }

            // Remove the category from the database
            _dbContext.Categories.Remove(categoryToDelete);
            await _dbContext.SaveChangesAsync();

            return categoryToDelete;
        }

        public async Task<Category> EditCategory(Category category)
        {
            // Check if the category exists in the database
            var existingCategory = await _dbContext.Categories.FindAsync(category.CategoryId);

            if (existingCategory == null)
            {
                // Handle the case where the category is not found
                return null;
            }

            // Update the existing category with the new values
            existingCategory.CategoryName = category.CategoryName;

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return existingCategory;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var getCategory = await _dbContext.Categories.Include(c => c.CategoryTypes).ToListAsync();
            return getCategory;
        }


    }
}
