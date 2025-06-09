using HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Notifications.Queries.GetNotificationListQuery;

public class UpdateNotificationCommandHandler(ICoreNotificationApi coreNotificationApi) : IRequestHandler<UpdateNotificationCommand, ApiBaseResponse<NotificationVm>>
{
    private readonly ICoreNotificationApi _coreNotificationApi = coreNotificationApi;

    public async Task<ApiBaseResponse<NotificationVm>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<NotificationVm>();
        try
        {
            var notification = await _coreNotificationApi.UpdateNotification(new UpdateNotificationRequest
            {
                AccountInfoId = request.AccountInfoId,
                IsRead = request.IsRead,
                NotificationId = request.NotificationId
            }, cancellationToken);

            response.Data = notification;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
