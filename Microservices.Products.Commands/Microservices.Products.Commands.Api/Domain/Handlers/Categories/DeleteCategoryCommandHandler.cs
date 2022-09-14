using MediatR;
using Microservices.Products.Commands.Api.Domain.Commands.Categories;
using Microservices.Products.Commands.Api.Domain.Events.Categories;
using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Shared.Enums;
using MinimalApi.Extensions.Shared.Notifications;

namespace Microservices.Products.Commands.Api.Domain.Handlers.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ICommandResult>
    {
        private readonly INotificationServices _notificationServices;
        private readonly IMediator _mediator;

        public DeleteCategoryCommandHandler(INotificationServices notificationServices, IMediator mediator)
        {
            _notificationServices = notificationServices;
            _mediator = mediator;
        }
        public async Task<ICommandResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (!request.IsValid)
            {
                _notificationServices.AddNotifications(request.Notifications.ToList(), StatusCodeOperation.BusinessError);
                return new CommandResult(_notificationServices.GetNotifications(), false, "Please, verify your data");
            }

            var categoryDeletedEvent = new CategoryDeletedEvent(request.Id);

            await _mediator.Publish(categoryDeletedEvent);

            return new CommandResult(categoryDeletedEvent.Id, true, "Success. Category Deleted!!");
        }
    }
}