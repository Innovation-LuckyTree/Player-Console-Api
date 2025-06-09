namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Notifications;
public class MarkAllAsReadResponse
{
    public bool Success { get; set; }
    public bool Data { get; set; }
    public string? ErrorMessage { get; set; }
}