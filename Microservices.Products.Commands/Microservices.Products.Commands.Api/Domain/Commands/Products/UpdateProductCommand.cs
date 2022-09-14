using Flunt.Validations;
using MediatR;
using Microservices.Products.Commands.Api.Domain.Commands.Bases;
using Microservices.Products.Commands.Api.Domain.Commands.Categories;
using MinimalApi.Extensions.Entities;

namespace Microservices.Products.Commands.Api.Domain.Commands.Products;

public class UpdateProductCommand : BaseEntity, IBaseCommand, IRequest<Guid>
{
    public Guid Id { get; private set; }
    public Guid CategoryId { get; private set; }
    public string? Name { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public UpdateProductCommand(Guid id, Guid categoryId, string? name, int quantity, decimal price)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public override void Validate()
    {
        AddNotifications(new Contract<AddCategoryCommand>()
                    .Requires()
                    .AreNotEquals(Id, Guid.Empty, nameof(Id), "CategoryId is Invalid")
                    .AreNotEquals(CategoryId, Guid.Empty, nameof(Id), "CategoryId is Invalid")
                    .IsNotNullOrEmpty(Name, nameof(Name), "Product Name is not Valid.")
                    .IsGreaterThan(Quantity, 0, nameof(Quantity), "Product Quantity must be greather than 0")
                    .IsGreaterThan(Price, 0, nameof(Price), "Product Price must be greather than 0"));
    }
}
