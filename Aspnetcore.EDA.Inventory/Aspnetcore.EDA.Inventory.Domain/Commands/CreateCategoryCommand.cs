using Aspnetcore.EDA.SharedContext.Base.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

namespace Aspnetcore.EDA.Inventory.Domain.Commands
{
    public class CreateCategoryCommand : Notifiable<Notification>, ICommand, ICommandValidate, IRequest<ICommandResult>
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsNotNullOrEmpty(CategoryName, nameof(CategoryName), "O nome é obrigatório")
               .IsNotNullOrEmpty(CategoryDescription, nameof(CategoryDescription), "A descrição é obrigatória"));

        }
    }
}
