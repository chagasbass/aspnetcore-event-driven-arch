using Aspnetcore.EDA.SharedContext.Base.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

namespace Aspnetcore.EDA.Inventory.Domain.Commands
{
    public class CreateProductCommand : Notifiable<Notification>, ICommand, ICommandValidate, IRequest<ICommandResult>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public CreateProductCommand()
        {

        }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .AreNotEquals(CategoryId, Guid.Empty, "A categoria é inválida.")
                .IsNotNullOrEmpty(Name, nameof(Name), "O nome é obrigatório.")
                .IsNotNullOrEmpty(Description, nameof(Description), "A descrição é obrigatória.")
                .IsGreaterThan(Price, 0, "O preço é inválida.")
                .IsGreaterThan(Quantity, 0, "A quantidade é inválida."));
        }
    }
}
