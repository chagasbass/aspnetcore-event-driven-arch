using MediatR;
using Microservices.Products.Commands.Api.Domain.Events.Categories;

namespace Microservices.Products.Commands.Api.Domain.EventHandlers.Categories;

public class CategoryCreatedEventHandler : INotificationHandler<CategoryCreatedEvent>
{
    public async Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CategoryUpdatedEventHandler : INotificationHandler<CategoryUpdatedEvent>
{
    public async Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CategoryDeletedEventHandler : INotificationHandler<CategoryDeletedEvent>
{
    public async Task Handle(CategoryDeletedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}