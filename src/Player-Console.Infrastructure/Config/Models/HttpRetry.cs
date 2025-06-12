namespace HP_Player_Console.Infrastructure.Config.Models;

public class HttpRetry
{
    public int BackoffPower { get; set; }
    public int Count { get; set; }
}
