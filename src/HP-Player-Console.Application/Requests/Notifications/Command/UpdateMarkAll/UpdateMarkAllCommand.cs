using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Notifications.Queries.GetNotificationListQuery;
public record UpdateMarkAllCommand(long AccountInfoId, bool IsRead) : IRequest<ApiBaseResponse<bool>>;
