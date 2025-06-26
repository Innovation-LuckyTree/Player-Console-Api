using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Users.Commands.BasicRegistration;
using HP_Player_Console.Application.Requests.Users.Commands.BasicVerification;
using HP_Player_Console.Application.Requests.Users.Queries.GetUserById;
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

        /// <summary>
        /// 
        /// Player basic verification
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("basic/verification")]
        public async Task<ActionResult> Post([FromBody] BasicVerificationCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// Get user information by AccountInfoId
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
            return Ok(result);
        }
    }
}
