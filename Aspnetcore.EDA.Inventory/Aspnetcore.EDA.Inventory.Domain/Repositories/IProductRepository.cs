using Aspnetcore.EDA.Inventory.Domain.Entities;

namespace Aspnetcore.EDA.Inventory.Domain.Repositories
{
    public interface IProductRepository
    {
        Task SaveProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task SaveCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(Guid categoryId);

    }
}
