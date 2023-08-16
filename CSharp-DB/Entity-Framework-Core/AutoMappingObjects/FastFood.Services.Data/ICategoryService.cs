using FastFood.Web.ViewModels.Categories;

namespace FastFood.Services.Data
{
    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryInputModel model);

        Task<IEnumerable<CategoryAllViewModel>> GetAllAsync();
    }
}
