using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Announcements.Queries.GetActiveAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace HappyPlay.API.Controllers
{
    public class AnnouncementController : ApiBaseController
    {
        /// <summary>
        /// Get active announcements
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="BranchId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveAnnouncements(string CompanyId, int BranchId, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetActiveAnnouncementsQuery(CompanyId, BranchId), cancellationToken);
            return Ok(result);
        }
    }
}
