using Microservices.Products.Commands.Api.Domain.Repositories;

namespace Microservices.Products.Commands.Api.Infrastructure.Data.Repositories;

public class EventModelRepository : IEventModelRepository
{
    private readonly EventStoreDataContext _context;

    public EventModelRepository(EventStoreDataContext context)
    {
        _context = context;
    }

    public async Task SaveEventAsync(EventModel eventModel) => await _context.Events.InsertOneAsync(eventModel).ConfigureAwait(false);

    public async Task<IEnumerable<EventModel>> GetEventByIdAsync(Guid aggregateId)
    {
        var events = await _context.Events.FindAsync(x => x.EventData.Id.Equals(aggregateId)).ConfigureAwait(false);

        return events.ToList();
    }
}