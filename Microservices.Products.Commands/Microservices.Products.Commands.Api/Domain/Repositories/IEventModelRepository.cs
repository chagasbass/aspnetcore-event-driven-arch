namespace Microservices.Products.Commands.Api.Domain.Repositories;
public interface IEventModelRepository
{
    Task SaveEventAsync(EventModel eventModel);
    Task<IEnumerable<EventModel>> GetEventByIdAsync(Guid aggregateId);
}