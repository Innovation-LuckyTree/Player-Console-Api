using HP_Player_Console.API.Controller;
using HP_Player_Console.Application.Requests.Notifications.Queries.GetNotificationListQuery;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controllers;

public class NotificationsController(ILogger<NotificationsController> logger) : ApiBaseController
{
    private readonly ILogger<NotificationsController> _logger = logger;

    [HttpPost("search")]
    public async Task<IActionResult> GetNotificationList(GetNotificationListQuery request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPut("mark-all")]
    public async Task<IActionResult> MarkAll(UpdateMarkAllCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateNotification(UpdateNotificationCommand request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}

