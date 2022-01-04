using Aspnetcore.EDA.Inventory.Domain.Enums;
using Aspnetcore.EDA.SharedContext.Base.Events;
using MediatR;

namespace Aspnetcore.EDA.Inventory.Domain.Events
{
    public class DeliveredOrderEvent : IDomainEvent, INotification
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Guid Id { get; set; }
        public DateTime OccuredAt { get; set; }

        public DeliveredOrderEvent(Guid orderId, Guid userId, OrderStatus orderStatus)
        {
            OrderId = orderId;
            UserId = userId;
            OrderStatus = orderStatus;

            Id = Guid.NewGuid();
            OccuredAt = DateTime.Now;
        }
    }
}
