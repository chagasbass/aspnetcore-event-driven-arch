namespace Microservices.Products.Commands.Api.Domain.Handlers.Categories;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ICommandResult>
{
    private readonly INotificationServices _notificationServices;
    private readonly IMediator _mediator;

    public UpdateCategoryCommandHandler(INotificationServices notificationServices, IMediator mediator)
    {
        _notificationServices = notificationServices;
        _mediator = mediator;
    }
    public async Task<ICommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        request.Validate();

        if (!request.IsValid)
        {
            _notificationServices.AddNotifications(request.Notifications.ToList(), StatusCodeOperation.BusinessError);
            return new CommandResult(_notificationServices.GetNotifications(), false, "Please, verify your data");
        }

        var categoryUpdatedEvent = new CategoryUpdatedEvent(request.Id, request.Name, request.Description);

        await _mediator.Publish(categoryUpdatedEvent);

        return new CommandResult(categoryUpdatedEvent.Id, true, "Success. Category updated!!");
    }
}