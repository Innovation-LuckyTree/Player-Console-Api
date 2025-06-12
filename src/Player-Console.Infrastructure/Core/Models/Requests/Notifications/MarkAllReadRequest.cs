namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;

public class MarkAllReadRequest
{
    public long AccountInfoId { get; set; }
    public bool IsRead { get; set; }
}

