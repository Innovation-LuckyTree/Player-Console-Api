using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Notifications;
public class NotificationSearchRequest
{
    public long AccountInfoId { get; set; }
    public bool? IsRead { get; set; }
    public PagedQuery? PagedQuery { get; set; }
}
