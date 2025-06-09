using HP_Player_Console.Requests.Profiles.Commands.UpdateAddress;
using HP_Player_Console.Requests.Profiles.Commands.UpdatePersonalDetails;
using HP_Player_Console.Requests.Profiles.Commands.UpdateProfessionCommand;
using HP_Player_Console.Requests.Profiles.Commands.UpdateProfileImage;
using HP_Player_Console.Requests.Profiles.Commands.UpdateProofInfo;
using HP_Player_Console.Requests.Profiles.Queries.GetPersonalDetails;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controller;

public class ProfileController : ApiBaseController
{
    [HttpGet("details")]
    public async Task<IActionResult> GetPersonalDetails(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetPersonalDetailsQuery(), cancellationToken);

        return Ok(response);
    }

    [HttpPatch("address")]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpPatch("personal-details")]
    public async Task<IActionResult> UpdatePersonalDetails(UpdatePersonalDetailsCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpPatch("profile-image")]
    public async Task<IActionResult> UpdateProfileImage(UpdateProfileImageCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpPatch("proof-info")]
    public async Task<IActionResult> UpdateProofInfo(UpdateProofInfoCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }
    [HttpPatch("profession")]
    public async Task<IActionResult> UpdateProfession(UpdateProfessionCommand request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        if (response == null)
            return NotFound();

        return Ok(response);
    }
}