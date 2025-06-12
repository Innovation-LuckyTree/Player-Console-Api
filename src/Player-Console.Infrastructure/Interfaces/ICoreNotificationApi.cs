using HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface ICoreNotificationApi
{
    Task PostAccountNotification(NotificationInfoRequest request, CancellationToken cancellationToken);
    Task PostAccountNotificationList(NotificationListRequest request, CancellationToken cancellationToken);
    Task PostNotificationByNameRequest(NotificationByNameRequest request, CancellationToken cancellationToken);
    Task<GetNotificationListResponse> GetSearchNotifications(NotificationSearchRequest request, CancellationToken cancellationToken);
    Task<MarkAllAsReadResponse> MarkAllReadNotification(MarkAllReadRequest request, CancellationToken cancellationToken);
    Task<NotificationVm> UpdateNotification(UpdateNotificationRequest request, CancellationToken cancellationToken);
}
