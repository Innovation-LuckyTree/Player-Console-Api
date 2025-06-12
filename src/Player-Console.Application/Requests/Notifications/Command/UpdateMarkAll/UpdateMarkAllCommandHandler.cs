
using HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Notifications.Queries.GetNotificationListQuery;

public class UpdateMarkAllCommandHandler(ICoreNotificationApi coreNotificationApi) : IRequestHandler<UpdateMarkAllCommand, ApiBaseResponse<bool>>
{
    private readonly ICoreNotificationApi _coreNotificationApi = coreNotificationApi;

    public async Task<ApiBaseResponse<bool>> Handle(UpdateMarkAllCommand request, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<bool>();
        try
        {
            var notifications = await _coreNotificationApi.MarkAllReadNotification(new MarkAllReadRequest
            {
                AccountInfoId = request.AccountInfoId,
                IsRead = request.IsRead
            }, cancellationToken);

            response.Data = true;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
