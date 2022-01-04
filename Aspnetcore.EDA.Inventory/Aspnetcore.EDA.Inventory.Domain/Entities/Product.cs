using Aspnetcore.EDA.SharedContext.Base.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace Aspnetcore.EDA.Inventory.Domain.Entities
{
    public class Product : Entity, IValidatableEntity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }

        public Product(Guid categoryId, string name, string description, decimal price, int quantity)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;

            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AddNotifications(new Contract<Notification>()
                 .Requires()
                 .AreNotEquals(CategoryId, Guid.Empty, "A categoria é inválida.")
                 .IsNotNullOrEmpty(Name, nameof(Name), "O nome é obrigatório.")
                 .IsNotNullOrEmpty(Description, nameof(Description), "A descrição é obrigatória.")
                 .IsGreaterThan(Price, 0, "O preço é inválida.")
                 .IsGreaterThan(Quantity, 0, "A quantidade é inválida."));
        }


        public Product ChangeName(string name)
        {
            Name = name;
            return this;
        }

        public Product ChangeDescription(string description)
        {
            Description = description;
            return this;
        }

        public Product ChangeCategory(Guid categoryId)
        {
            CategoryId = categoryId;
            return this;
        }

        public Product ChangePrice(decimal price)
        {
            Price = price;
            return this;
        }
    }
}
