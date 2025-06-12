using HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Notifications.Queries.GetNotificationListQuery;
public record UpdateNotificationCommand(long AccountInfoId, long NotificationId, bool IsRead) : IRequest<ApiBaseResponse<NotificationVm>>;
