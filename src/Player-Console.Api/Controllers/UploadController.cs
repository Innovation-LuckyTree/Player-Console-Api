using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Uploads.Commands.UploadStringImage;
using HP_Player_Console.Application.Requests.Uploads.Queries.GetImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.Api.Controllers
{
    public class UploadController : ApiBaseController
    {
        /// <summary>
        /// 
        /// Upload base64 image
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("base64image")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadBase64Image(UploadStringImageCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// Get image
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{fileName}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetImage(string fileName, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetImageQuery(fileName), cancellationToken);
            return Ok(result);
        }
    }
}
