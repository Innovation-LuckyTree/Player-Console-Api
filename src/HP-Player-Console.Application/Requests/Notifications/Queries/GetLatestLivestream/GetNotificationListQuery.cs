using HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
using HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Notifications.Queries.GetNotificationListQuery;
public record GetNotificationListQuery(NotificationSearchRequest Data) : IRequest<ApiBaseResponse<GetNotificationListResponse>>;
