using HP_Player_Console.API.Controller;
using HP_Player_Console.Requests.SelfExclusion.Commands.CreateNewExclusion;
using HP_Player_Console.Requests.SelfExclusion.Commands.UpdateActiveExclusion;
using HP_Player_Console.Requests.SelfExclusion.Queries.GetActiveExclusion;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class SelfExclusionController : ApiBaseController
{
    private readonly ILogger<SelfExclusionController> _logger;

    public SelfExclusionController(ILogger<SelfExclusionController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSelfExclusion(CreateNewExclusionCommand query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateActiveExclusion(UpdateActiveExclusionCommand query, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetActiveExclusion(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetActiveExclusionQuery(), cancellationToken);

        return Ok(result);
    }
}

