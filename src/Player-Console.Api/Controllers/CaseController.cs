using HappyPlay.Application.Requests.Cases.Commands.CreateCase;
using HappyPlay.Application.Requests.Cases.Queries.CaseOrganizations;
using HappyPlay.Application.Requests.Cases.Queries.CaseStatuses;
using HappyPlay.Application.Requests.Cases.Queries.GetCaseById;
using HappyPlay.Application.Requests.Cases.Queries.GetCategoryByType;
using HappyPlay.Application.Requests.Cases.Queries.GetCategoryList;
using HappyPlay.Application.Requests.Cases.Queries.SearchCases;
using Microsoft.AspNetCore.Mvc;

namespace HP_Player_Console.API.Controller;

public class CaseController : ApiBaseController
{
    [HttpGet("{caseId}")]
    public async Task<IActionResult> GetCaseById(long caseId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCaseByIdQuery(caseId), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCaseCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchCase([FromBody] SearchCasesQuery request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("statuses")]
    public async Task<IActionResult> GetStatuses(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCaseStatusesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("organizations")]
    public async Task<IActionResult> GetOrganizations(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new CaseOrganizationsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("category")]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCategoryListQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("category/type/{typeId}")]
    public async Task<IActionResult> GetCategoryByType(int typeId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCategoryByTypeQuery(typeId), cancellationToken);
        return Ok(result);
    }
}