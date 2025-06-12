using HP_Player_Console.Infrastructure.Config.Models;

namespace HP_Player_Console.Infrastructure.Config.Models;

public class ApiPolicyConfig
{
    public HttpCircuitBreaker HttpCircuitBreaker { get; set; }
    public HttpRetry HttpRetry { get; set; }
}
