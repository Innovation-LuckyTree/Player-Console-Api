using HP_Player_Console.Infrastructure.HubClient.Models;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface IHubClientApi
{
    Task<LuckyPickResponse> GetLuckyPick(int count, CancellationToken cancellationToken);
}
