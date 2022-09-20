namespace Microservices.Products.Commands.Api.Domain.Events.Categories;

public class CategoryUpdatedEvent : BaseEvent
{
    public Guid AggregateId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public CategoryUpdatedEvent(Guid id, string? name, string? description)
        : base(nameof(CategoryUpdatedEvent), OperationType.Update, "")
    {
        AggregateId = id;
        Name = name;
        Description = description;
    }
}
