using AutoMapper;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Notifications.Queries.GetNotificationListQuery;

public class GetNotificationListQueryHandler(ICoreNotificationApi coreNotificationApi) : IRequestHandler<GetNotificationListQuery, ApiBaseResponse<GetNotificationListResponse>>
{
    private readonly ICoreNotificationApi _coreNotificationApi = coreNotificationApi;

    public async Task<ApiBaseResponse<GetNotificationListResponse>> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<GetNotificationListResponse>();
        try
        {
            var notifications = await _coreNotificationApi.GetSearchNotifications(request.Data, cancellationToken);

            response.Data = notifications;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
