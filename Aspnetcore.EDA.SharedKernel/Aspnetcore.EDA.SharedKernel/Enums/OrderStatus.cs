using Aspnetcore.EDA.SharedContext.Base.Enums;

namespace Aspnetcore.EDA.Inventory.Domain.Enums
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus Delivered { get; } = new OrderStatus(1, nameof(Delivered));
        public static OrderStatus OutOfStock { get; } = new OrderStatus(2, nameof(OutOfStock));
        public static OrderStatus Shipping { get; } = new OrderStatus(3, nameof(Shipping));

        public OrderStatus(int id, string name) : base(id, name) { }

    }
}
