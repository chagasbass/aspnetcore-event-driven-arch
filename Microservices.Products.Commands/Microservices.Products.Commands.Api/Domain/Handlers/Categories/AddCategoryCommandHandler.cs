using MediatR;
using Microservices.Products.Commands.Api.Domain.Commands.Categories;
using Microservices.Products.Commands.Api.Domain.Events.Categories;
using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Shared.Enums;
using MinimalApi.Extensions.Shared.Notifications;

namespace Microservices.Products.Commands.Api.Domain.Handlers.Categories
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ICommandResult>
    {
        private readonly INotificationServices _notificationServices;
        private readonly IMediator _mediator;

        public AddCategoryCommandHandler(INotificationServices notificationServices, IMediator mediator)
        {
            _notificationServices = notificationServices;
            _mediator = mediator;
        }
        public async Task<ICommandResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (!request.IsValid)
            {
                _notificationServices.AddNotifications(request.Notifications.ToList(), StatusCodeOperation.BusinessError);
                return new CommandResult(_notificationServices.GetNotifications(), false, "Please, verify your data");
            }

            var categoryCreatedEvent = new CategoryCreatedEvent(request.Name, request.Description);

            await _mediator.Publish(categoryCreatedEvent);

            return new CommandResult(categoryCreatedEvent.Id, true, "Success. Category created!!");
        }
    }
}