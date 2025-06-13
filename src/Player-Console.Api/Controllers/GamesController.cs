using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Games.Queries.GetGameByGameId;
using HP_Player_Console.Application.Requests.Games.Queries.GetHuiduGames;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class GamesController(ILogger<GamesController> logger) : ApiBaseController
{
    [HttpGet("catalog")]
    public async Task<IActionResult> GetGames(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetGamesListQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("load/{id}")]
    public async Task<IActionResult> GetGames(string id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetGameByGameIdQuery(id), cancellationToken);

        return Ok(result);
    }
}