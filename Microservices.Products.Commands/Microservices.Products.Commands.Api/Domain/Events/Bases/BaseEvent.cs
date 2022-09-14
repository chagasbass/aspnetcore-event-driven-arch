using MediatR;
using Microservices.Products.Commands.Api.Domain.Enums;

namespace Microservices.Products.Commands.Api.Domain.Messages.Bases;

public abstract class BaseEvent : INotification
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string? EventType { get; set; }
    public OperationType OperationType { get; set; }
    public DateTime EventDate { get; set; }
    public string? TopicName { get; set; }

    protected BaseEvent(string? type, OperationType operationType, string? topicName)
    {
        EventType = type;
        OperationType = operationType;
        EventDate = DateTime.Now;
        TopicName = topicName;
    }
}