using HP_Player_Console.Infrastructure.Core.Models.Responses.Case;
using HP_Player_Console.Infrastructure.Support.Requests;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface ISupportClientApi
{
    Task<object> CreateCase(CreateCaseRequest request, CancellationToken cancellationToken);
    Task<object> UpdateCaseOwner(UpdateCaseOwnerRquest request, CancellationToken cancellationToken);
    Task<object> SearchCases(SearchCaseRequest request, CancellationToken cancellationToken);
    Task<object> GetCaseStatuses(CancellationToken cancellationToken);
    Task<CaseDto> GetCaseById(long caseId, CancellationToken cancellationToken);
    Task<object> GetCaseOrganizations(CancellationToken cancellationToken);
    Task<object> GetCategoryList(CancellationToken cancellationToken);
    Task<object> GetCategoryByType(int typeId, CancellationToken cancellationToken);
    Task<IEnumerable<CommentDto>> GetCaseComments(long CaseId, CancellationToken cancellationToken);
}
