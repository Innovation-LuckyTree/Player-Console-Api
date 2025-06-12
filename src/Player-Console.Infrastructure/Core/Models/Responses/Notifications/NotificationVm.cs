namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;

public class NotificationVm
{
    public int AccountInfoId { get; set; }
    public int NotificationId { get; set; }
    public int NotificationTypeId { get; set; }
    public bool IsRead { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RedirectUrl { get; set; }
    public DateTime TransactionDate { get; set; }
}
