using Microservices.Products.Commands.Api.Domain.Enums;
using Microservices.Products.Commands.Api.Domain.Messages.Bases;

namespace Microservices.Products.Commands.Api.Domain.Events.Categories;

public class CategoryUpdatedEvent : BaseEvent
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public CategoryUpdatedEvent(Guid id, string? name, string? description) : base(nameof(CategoryUpdatedEvent), OperationType.Update)
    {
        Id = id;
        Name = name;
        Description = description;

    }
}
