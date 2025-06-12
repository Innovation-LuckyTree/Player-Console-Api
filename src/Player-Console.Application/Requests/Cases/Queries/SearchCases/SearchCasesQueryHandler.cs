using AutoMapper;
using HP_Player_Console.Common.Interfaces;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Support.Requests;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.SearchCases;

public class SearchCasesQueryHandler : IRequestHandler<SearchCasesQuery, object>
{
    private readonly ISupportClientApi _supportApi;
    private readonly ICurrentUserService _currentUserService;

    public SearchCasesQueryHandler(ISupportClientApi supportApi, ICurrentUserService currentUserService)
    {
        _supportApi = supportApi;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(SearchCasesQuery request, CancellationToken cancellationToken)
    {
        return await _supportApi.SearchCases(new SearchCaseRequest
        {
            Title = request.Title,
            CaseId = request.CaseId,
            StartDate = request.StartDate,
            Status = request.Status,
            EndDate = request.EndDate,
            UserId = _currentUserService.UserId,
            PagedQuery = request.PagedQuery
        }, cancellationToken);
    }
}
