using Aspnetcore.EDA.Inventory.Domain.Queries;

namespace Aspnetcore.EDA.Inventory.Domain.Repositories
{
    public interface IProductQueryRepository
    {
        Task<ProductQuery> ListProductAsync(Guid productId);
        Task<IEnumerable<ProductQuery>> ListProductAsync();
        Task<bool> VerifyProductAsync(string name);
    }
}
