namespace Microservices.Products.Commands.Api.Domain.Events.Products;

public class ProductDeletedEvent : BaseEvent
{
    public ProductDeletedEvent(Guid id)
        : base(nameof(ProductDeletedEvent), OperationType.Delete, "")
    {
        Id = id;
    }
}
