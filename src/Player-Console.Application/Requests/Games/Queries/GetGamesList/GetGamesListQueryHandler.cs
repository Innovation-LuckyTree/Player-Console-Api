using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Games.Queries.GetHuiduGames;

public class GetGamesListQueryHandler(IHuiduClientApi huiduClientApi) : IRequestHandler<GetGamesListQuery, GameVm>
{
    private readonly IHuiduClientApi _huiduClientApi = huiduClientApi;

    public async Task<GameVm> Handle(GetGamesListQuery request, CancellationToken cancellationToken)
    {
        var games = GetGames();
        return new GameVm(games);
    }

    private IEnumerable<GameDto> GetGames()
    {
        return
        [
            new() {
                GameId = "c3d9125886cdd573a4404e6121877754",
                GameName = "Aztec Treasure Hunt",
                GameType = "Casino"
            },
            new() {
                GameId = "276582955d8f162b3379939a3eb5b038",
                GameName = "Volcano Goddess",
                GameType = "Slot"
            },
            new() {
                GameId = "6310a699c52341452fac399be10a2b48",
                GameName = "Roulette 1 - Azure",
                GameType = "Casino"
            },
            new() {
                GameId = "a92a531d389c718b5f5f82cfc2448e39",
                GameName = "Blackjack X 1 - Azure",
                GameType = "Casino"
            },
            new() {
                GameId = "a92a531d389c718b5f5f82cfc2448e39",
                GameName = "Blackjack X 1 - Azure",
                GameType = "Casino"
            },
            new() {
                GameId = "8a0b30eb466a8a07027cbddc19369d0f",
                GameName = "Gem Fire Fortune",
                GameType = "Slot"
            },
            new() {
                GameId = "91cd6233551cd56e70d900794ed728e3",
                GameName = "Wild West Gold Blazing Bounty",
                GameType = "Slot"
            },
            new() {
                GameId = "91cd6233551cd56e70d900794ed728e3",
                GameName = "Finger Lick’n Free Spins",
                GameType = "Slot"
            },
            new() {
                GameId = "e1d2da140286507e851fde1cb2fdd4ba",
                GameName = "Gold Party 2 – After Hours",
                GameType = "Slot"
            }
        ];
    }
}   