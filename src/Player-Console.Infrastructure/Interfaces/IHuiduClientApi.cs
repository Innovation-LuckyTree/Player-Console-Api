namespace HP_Player_Console.Infrastructure.Interfaces;

public interface IHuiduClientApi
{
    Task<string> GetGame(string accountId, string gameId, string amount, CancellationToken cancellationToken);
}
