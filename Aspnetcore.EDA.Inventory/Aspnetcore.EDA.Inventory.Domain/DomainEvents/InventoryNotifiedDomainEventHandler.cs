using Aspnetcore.EDA.Inventory.Domain.DomainServices;
using Aspnetcore.EDA.Inventory.Domain.Repositories;
using Aspnetcore.EDA.SharedContext.Base.Events;
using MediatR;

namespace Aspnetcore.EDA.Inventory.Domain.DomainEvents
{
    public class InventoryNotifiedDomainEventHandler : INotificationHandler<InventoryNotifiedEvent>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDomainService _productDomainService;

        public InventoryNotifiedDomainEventHandler(IProductRepository productRepository, IProductDomainService productDomainService)
        {
            _productRepository = productRepository;
            _productDomainService = productDomainService;
        }

        public async Task Handle(InventoryNotifiedEvent notification, CancellationToken cancellationToken)
        {
            //recupera o produto
            //diminui a quantidade
            //altera o status 


            throw new NotImplementedException();
        }
    }
}
