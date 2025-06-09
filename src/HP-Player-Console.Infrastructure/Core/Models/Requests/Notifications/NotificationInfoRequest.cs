namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;

public record NotificationInfoRequest
{
    public long AccountInfoId { get; set; }
    public int NotificationTypeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RedirectUrl { get; set; }
}
