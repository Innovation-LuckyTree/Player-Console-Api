namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;
public record GetNotificationListResponse(IEnumerable<NotificationVm> Notifications)
{
    public int TotalUnreadCount { get; set; }
    public int TotalReadCount { get; set; }
    public int Total { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}