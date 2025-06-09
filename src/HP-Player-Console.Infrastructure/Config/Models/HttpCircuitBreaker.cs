namespace HP_Player_Console.Infrastructure.Config.Models;

public class HttpCircuitBreaker
{
    public string DurationOfBreak { get; set; }
    public int ExceptionsAllowedBeforeBreaking { get; set; }
}
