using MediatR;

namespace Aspnetcore.EDA.SharedContext.Base.Events
{
    public class InventoryNotifiedEvent : IDomainEvent, INotification
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OccuredAt { get; set; }

        public InventoryNotifiedEvent(Guid orderId, Guid userId, string userName, string shippingAddress)
        {
            OrderId = orderId;
            UserId = userId;
            UserName = userName;
            ShippingAddress = shippingAddress;

            Id = Guid.NewGuid();
            OccuredAt = DateTime.Now;
        }
    }
}
