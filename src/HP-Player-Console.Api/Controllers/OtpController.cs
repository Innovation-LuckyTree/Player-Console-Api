using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Otps.Commands.GenerateOtp;
using HP_Player_Console.Application.Requests.Otps.Commands.VerifyOtp;
using HP_Player_Console.Application.Requests.Otps.Queries.GetPendingOtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class OtpController : ApiBaseController
{
    private readonly ILogger<OtpController> _logger;

    public OtpController(ILogger<OtpController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// will generate mobile OTP if the mobile number is valid
    /// </summary>
    /// <param name="generateOtpCommand"></param>
    /// <param name="cancellationToken"></param>    
    /// <returns>OTP reference ID</returns>
    [AllowAnonymous]
    [HttpPost("generateOTP")]
    public async Task<ActionResult> GenerateOTP(GenerateOtpCommand generateOtpCommand, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Mediator.Send(generateOtpCommand, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("Mobile number is not registered.");
        }
    }

    /// <summary>
    /// Verify OTP request
    /// </summary>
    /// <param name="verifyOtpCommand">ReferenceId from generatedOTP response, Mobile Number, OtpCode</param>
    /// <param name="cancellationToken"></param>
    /// <returns>should return success http code request</returns>
    [AllowAnonymous]
    [HttpPut("verify")]
    public async Task<ActionResult> verifyOTP(VerifyOtpCommand verifyOtpCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(verifyOtpCommand, cancellationToken);
        return Ok(result);
    }

    // /// <summary>
    // /// Get all pending Otp
    // /// </summary>
    // /// <param name="cancellationToken"></param>
    // /// <returns>all OTP data that are not yet confirmed</returns>
    // [AllowAnonymous]
    // [HttpGet("pending")]
    // public async Task<ActionResult> GetPendingOTP(CancellationToken cancellationToken)
    // {
    //     var result = await Mediator.Send(new GetPendingOtpQuery(), cancellationToken);
    //     return Ok(result);
    // }
}