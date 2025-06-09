namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;

public record NotificationByNameRequest
{
    public IEnumerable<long> Accounts { get; set; }
    public int NotificationTypeId { get; set; }
    public string Name { get; set; }
    public IEnumerable<string>? Parameters { get; set; }
}
