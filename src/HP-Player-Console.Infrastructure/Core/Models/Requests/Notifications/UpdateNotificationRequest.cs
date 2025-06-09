namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
public class UpdateNotificationRequest
{
    public long AccountInfoId { get; set; }
    public long NotificationId { get; set; }
    public bool IsRead { get; set; }
}
