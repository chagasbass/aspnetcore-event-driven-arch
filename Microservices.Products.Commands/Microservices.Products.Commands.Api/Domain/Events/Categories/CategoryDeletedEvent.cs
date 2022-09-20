namespace Microservices.Products.Commands.Api.Domain.Events.Categories;

public class CategoryDeletedEvent : BaseEvent
{
    public Guid AggregateId { get; private set; }

    public CategoryDeletedEvent(Guid id) : base(nameof(CategoryDeletedEvent), OperationType.Delete, "")
    {
        AggregateId = id;
    }
}