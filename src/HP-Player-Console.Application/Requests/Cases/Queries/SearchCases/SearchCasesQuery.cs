using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Support.Requests;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.SearchCases;

public class SearchCasesQuery : IRequest<object>
{
    public string CaseId { get; set; }
    public string Title { get; set; }
    public int? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CasePagedQuery PagedQuery { get; set; }
}
