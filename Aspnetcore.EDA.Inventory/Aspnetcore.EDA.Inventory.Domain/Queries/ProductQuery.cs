namespace Aspnetcore.EDA.Inventory.Domain.Queries
{
    public class ProductQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ProductQuery()
        {

        }
    }
}
