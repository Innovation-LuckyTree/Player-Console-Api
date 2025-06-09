namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;

public record NotificationListRequest
{
    public IEnumerable<NotificationInfoRequest> AccountNotifications { get; set; }
}
