namespace Microservices.Products.Commands.Api.Domain.Events.Categories;

public class CategoryCreatedEvent : BaseEvent
{
    public Guid AggregateId { get; private set; } = Guid.NewGuid();
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public CategoryCreatedEvent(string? name, string? description)
        : base(nameof(CategoryCreatedEvent), OperationType.Create, "")
    {
        Name = name;
        Description = description;

    }
}