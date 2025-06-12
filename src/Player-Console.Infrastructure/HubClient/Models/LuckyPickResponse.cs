namespace HP_Player_Console.Infrastructure.HubClient.Models;

public record LuckyPickResponse(IEnumerable<LuckyPickInfo> LuckyPick)
{
    public int Count
    {
        get => LuckyPick?.Count() ?? 0;
        
    }
}

public class LuckyPickInfo
{
    public string Value { get; set; }
    public int Count { get; set; }
}