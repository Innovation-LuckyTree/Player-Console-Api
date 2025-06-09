using HP_Player_Console.Application.Requests.Accounts.Queries.GetAuthByTokenDevice;
using HP_Player_Console.Application.Requests.Accounts.Queries.GetRefreshToken;
using HP_Player_Console.Application.Requests.Accounts.Queries.GetUserToken;
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

    [HttpPost("token/refresh")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken([FromBody] GetRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    /// <summary>
    /// Get User Token using user credentials
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("token")]
    [AllowAnonymous]
    public async Task<IActionResult> GetTenantToken([FromBody] GetAuthByTokenDeviceQuery request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        
        if (!response.Success)
            return BadRequest(response);
            
        return Ok(response);
    }
}