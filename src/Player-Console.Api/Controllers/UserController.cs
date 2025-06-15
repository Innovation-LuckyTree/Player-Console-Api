using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Users.Commands.BasicRegistration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.Api.Controllers
{
    public class UserController : ApiBaseController
    {
        /// <summary>
        /// 
        /// Player basic registration
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("basic/registration")]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] BasicRegistrationCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
