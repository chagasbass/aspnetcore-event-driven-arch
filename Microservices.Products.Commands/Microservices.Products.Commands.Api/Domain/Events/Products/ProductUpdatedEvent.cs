namespace Microservices.Products.Commands.Api.Domain.Events.Products;

public class ProductUpdatedEvent : BaseEvent
{
    public Guid CategoryId { get; private set; }
    public string? Name { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public ProductUpdatedEvent(Guid id, Guid categoryId, string? name, int quantity, decimal price)
        : base(nameof(ProductUpdatedEvent), OperationType.Create, "")
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
