using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controller;

public class AuthController : ApiBaseController
{
    /// <summary>
    /// Get User Token using user credentials
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("account/login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] GetAuthTokenQuery request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }
}