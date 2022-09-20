using Microservices.Products.Commands.Api.Domain.Repositories;

namespace Microservices.Products.Commands.Api.Domain.EventHandlers.Categories;

public class CategoryCreatedEventHandler : INotificationHandler<CategoryCreatedEvent>
{
    private readonly IEventModelRepository _eventModelRepository;

    public CategoryCreatedEventHandler(IEventModelRepository eventModelRepository)
    {
        _eventModelRepository = eventModelRepository;
    }

    public async Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        var createdEvents = await _eventModelRepository.GetEventByIdAsync(notification.AggregateId);

        if (createdEvents.Any(x => x.EventDataType.Equals(nameof(CategoryCreatedEvent))))
        {
            return;
        }

        var version = createdEvents.LastOrDefault().EventData.Version + 1;

        notification.Version = version;

        var addCategoryEventModel = new EventModel(notification, nameof(CategoryCreatedEvent));

        await _eventModelRepository.SaveEventAsync(addCategoryEventModel);

        //sends to kafka
    }
}

public class CategoryUpdatedEventHandler : INotificationHandler<CategoryUpdatedEvent>
{
    private readonly IEventModelRepository _eventModelRepository;

    public CategoryUpdatedEventHandler(IEventModelRepository eventModelRepository)
    {
        _eventModelRepository = eventModelRepository;
    }

    public async Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var addCategoryEventModel = new EventModel(notification, nameof(CategoryUpdatedEvent));

        await _eventModelRepository.SaveEventAsync(addCategoryEventModel);

    }
}

public class CategoryDeletedEventHandler : INotificationHandler<CategoryDeletedEvent>
{
    private readonly IEventModelRepository _eventModelRepository;

    public CategoryDeletedEventHandler(IEventModelRepository eventModelRepository)
    {
        _eventModelRepository = eventModelRepository;
    }

    public async Task Handle(CategoryDeletedEvent notification, CancellationToken cancellationToken)
    {
        var addCategoryEventModel = new EventModel(notification, nameof(CategoryDeletedEvent));

        await _eventModelRepository.SaveEventAsync(addCategoryEventModel);
    }
}