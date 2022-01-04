using Aspnetcore.EDA.Inventory.Domain.Commands;
using Aspnetcore.EDA.Inventory.Domain.Entities;
using Aspnetcore.EDA.Inventory.Domain.Repositories;
using Aspnetcore.EDA.SharedContext.Base.Commands;
using Flunt.Notifications;
using MediatR;

namespace Aspnetcore.EDA.Inventory.Domain.Handlers
{
    public class CreateCategoryHandler : Notifiable<Notification>, IRequestHandler<CreateCategoryCommand, ICommandResult>
    {
        private readonly IProductRepository _productRepository;

        public CreateCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (!request.IsValid)
            {
                return new CommandResult(request.Notifications);
            }

            var newCategory = new Category(request.CategoryName, request.CategoryDescription);

            await _productRepository.SaveCategoryAsync(newCategory);

            return new CommandResult(newCategory, "Categoria cadastrada com sucesso", true);
        }
    }
}
