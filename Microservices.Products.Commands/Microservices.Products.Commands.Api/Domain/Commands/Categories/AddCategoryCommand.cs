namespace Microservices.Products.Commands.Api.Domain.Commands.Categories;

public class AddCategoryCommand : BaseEntity, IRequest<ICommandResult>, IBaseCommand
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public AddCategoryCommand(string? name, string? description)
    {
        Name = name;
        Description = description;
    }

    public override void Validate()
    {
        AddNotifications(new Contract<AddCategoryCommand>()
                         .Requires()
                         .IsNotNullOrEmpty(Name, nameof(Name), "Category Name is not Valid.")
                         .IsNotNullOrEmpty(Description, nameof(Description), "Category Description is not valid"));
    }
}