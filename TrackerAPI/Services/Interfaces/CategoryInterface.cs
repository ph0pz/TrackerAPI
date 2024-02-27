using TrackerData;

namespace TrackerAPI.Services.Interfaces
{
    public interface CategoryInterface
    {
        Task<List<Category>> GetAllCategory();

        Task<Category> AddCategory(Category category);

        Task<Category> DeleteCategory(int categoryId);

        Task<Category> EditCategory(Category category);




    }
}
