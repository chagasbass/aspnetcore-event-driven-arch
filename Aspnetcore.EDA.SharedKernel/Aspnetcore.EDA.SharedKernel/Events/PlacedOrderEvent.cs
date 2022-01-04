using MediatR;

namespace Aspnetcore.EDA.SharedContext.Base.Events
{
    public class PlacedOrderEvent : IDomainEvent, INotification
    {
        public Guid Id { get; set; }
        public DateTime OccuredAt { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public PlacedOrderEvent(Guid orderId, Guid userId, string userName)
        {
            OrderId = orderId;
            UserId = userId;
            UserName = userName;

            Id = Guid.NewGuid();
            OccuredAt = DateTime.Now;
        }
    }
}
