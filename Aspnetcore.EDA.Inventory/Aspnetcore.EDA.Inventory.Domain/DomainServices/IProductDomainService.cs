using Aspnetcore.EDA.Inventory.Domain.Entities;

namespace Aspnetcore.EDA.Inventory.Domain.DomainServices
{
    public interface IProductDomainService
    {
        Task ChangeQuantityAsync(Product product);
    }
}
