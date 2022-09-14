using Microservices.Products.Commands.Api.Domain.Enums;
using Microservices.Products.Commands.Api.Domain.Messages.Bases;

namespace Microservices.Products.Commands.Api.Domain.Events.Products;

public class ProductCreatedEvent : BaseEvent
{
    public Guid CategoryId { get; private set; }
    public string? Name { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public ProductCreatedEvent(Guid categoryId, string? name, int quantity, decimal price) : base(nameof(ProductCreatedEvent), OperationType.Create)
    {
        Id = Guid.NewGuid();
        CategoryId = categoryId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
