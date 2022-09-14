using Microservices.Products.Commands.Api.Domain.Enums;
using Microservices.Products.Commands.Api.Domain.Messages.Bases;

namespace Microservices.Products.Commands.Api.Domain.Events.Categories;

public class CategoryDeletedEvent : BaseEvent
{
    public Guid Id { get; private set; }

    public CategoryDeletedEvent(Guid id) : base(nameof(CategoryDeletedEvent), OperationType.Delete)
    {
        Id = id;
    }
}