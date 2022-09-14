using Flunt.Validations;
using MediatR;
using Microservices.Products.Commands.Api.Domain.Commands.Bases;
using Microservices.Products.Commands.Api.Domain.Commands.Categories;
using MinimalApi.Extensions.Entities;

namespace Microservices.Products.Commands.Api.Domain.Commands.Products;

public class DeleteProductCommand : BaseEntity, IBaseCommand, IRequest<Guid>
{
    public Guid Id { get; private set; }
    public override void Validate()
    {
        AddNotifications(new Contract<AddCategoryCommand>()
                   .Requires()
                   .AreNotEquals(Id, Guid.Empty, nameof(Id), "Product Id is Invalid"));
    }
}