using Aspnetcore.EDA.Inventory.Domain.Entities;
using Aspnetcore.EDA.Inventory.Domain.Repositories;

namespace Aspnetcore.EDA.Inventory.Domain.DomainServices
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ChangeQuantityAsync(Product product)
        {
            product.ValidateEntity();

            if (!product.IsValid)
                return;

            await _productRepository.UpdateProductAsync(product);

        }
    }
}
