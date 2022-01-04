using Aspnetcore.EDA.Inventory.Domain.Commands;
using Aspnetcore.EDA.Inventory.Domain.Entities;
using Aspnetcore.EDA.Inventory.Domain.Repositories;
using Aspnetcore.EDA.SharedContext.Base.Commands;
using Flunt.Notifications;
using MediatR;

namespace Aspnetcore.EDA.Inventory.Domain.Handlers
{
    public class CreateProductHandler : Notifiable<Notification>, IRequestHandler<CreateProductCommand, ICommandResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductQueryRepository _productQueryRepository;

        public CreateProductHandler(IProductRepository productRepository, IProductQueryRepository productQueryRepository)
        {
            _productRepository = productRepository;
            _productQueryRepository = productQueryRepository;
        }

        public async Task<ICommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (!request.IsValid)
            {
                return new CommandResult(request.Notifications);
            }

            var isProductExists = await _productQueryRepository.VerifyProductAsync(request.Name);

            if (isProductExists)
            {
                AddNotification("Produto", "O Produto já está cadastrado");
                return new CommandResult(this.Notifications);
            }

            var newProduct = new Product(request.CategoryId, request.Name, request.Description, request.Price, request.Quantity);

            if (!newProduct.IsValid)
            {
                return new CommandResult(newProduct.Notifications);
            }

            await _productRepository.SaveProductAsync(newProduct);

            return new CommandResult(newProduct, "Cadastrado com sucesso", true);
        }
    }
}
