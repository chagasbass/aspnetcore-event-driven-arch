using Flunt.Validations;
using MediatR;
using Microservices.Products.Commands.Api.Domain.Commands.Bases;
using MinimalApi.Extensions.Entities;

namespace Microservices.Products.Commands.Api.Domain.Commands.Categories;

public class DeleteCategoryCommand : BaseEntity, IBaseCommand, IRequest<ICommandResult>
{
    public Guid Id { get; private set; }

    public DeleteCategoryCommand(Guid id)
    {
        Id = id;
    }
    public override void Validate()
    {
        AddNotifications(new Contract<AddCategoryCommand>()
                         .Requires()
                         .AreNotEquals(Id, Guid.Empty, nameof(Id), "Category Id is Invalid"));
    }
}