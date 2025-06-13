namespace HP_Player_Console.Application.Requests.Games.Queries.GetHuiduGames;

public record GameVm(IEnumerable<GameDto> Games)  
{
    public int Count { get => Games.Count(); }
}
