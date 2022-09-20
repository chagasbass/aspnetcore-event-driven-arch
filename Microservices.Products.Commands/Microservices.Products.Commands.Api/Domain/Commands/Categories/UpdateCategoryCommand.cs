namespace Microservices.Products.Commands.Api.Domain.Commands.Categories;

public class UpdateCategoryCommand : BaseEntity, IBaseCommand, IRequest<ICommandResult>
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public UpdateCategoryCommand(Guid id, string? name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public override void Validate()
    {
        AddNotifications(new Contract<AddCategoryCommand>()
                        .Requires()
                        .AreNotEquals(Id, Guid.Empty, nameof(Id), "Category Id is Invalid")
                        .IsNotNullOrEmpty(Name, nameof(Name), "Category Name is not Valid.")
                        .IsNotNullOrEmpty(Description, nameof(Description), "Category Description is not valid"));
    }
}
