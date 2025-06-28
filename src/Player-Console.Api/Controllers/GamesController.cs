using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Games.Queries.GetGameByGameId;
using HP_Player_Console.Application.Requests.Games.Queries.GetGameCategories;
using HP_Player_Console.Application.Requests.Games.Queries.GetGameProviderList;
using HP_Player_Console.Application.Requests.Games.Queries.GetGamesByProviderAndCategory;
using HP_Player_Console.Application.Requests.Games.Queries.GetHuiduGames;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("categories")]
    public async Task<IActionResult> GetGameCategories(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetGameCategoriesQuery(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("{categoryId}/providers")]
    [AllowAnonymous]
    public async Task<IActionResult> GetGameProviders(int categoryId, [FromForm] bool isFavorite, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetGameProviderListQuery(categoryId, isFavorite), cancellationToken);

        return Ok(result);
    }

    [HttpGet("{gameCategoryId}/{providerId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetGameProviderByCategoryId(int gameCategoryId, int providerId, [FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetGamesByProviderAndCategoryQuery(gameCategoryId, providerId, pageNumber, pageSize), cancellationToken);

        return Ok(result);
    }

    [HttpGet("load/{id}")]
    public async Task<IActionResult> GetGames(string id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetGameByGameIdQuery(id), cancellationToken);

        return Ok(result);
    }
}