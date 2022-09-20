namespace Microservices.Products.Commands.Api.Infrastructure.Messagings.Base;

public class EventModel
{
    public ObjectId Id { get; set; }
    public BaseEvent EventData { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public string? EventDataType { get; set; }

    public EventModel(BaseEvent eventData, string eventDataType)
    {
        EventData = eventData;
        EventDataType = eventDataType;
    }
}
