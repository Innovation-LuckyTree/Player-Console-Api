using HP_Player_Console.Infrastructure.Core.Models.Requests.Announcements;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Announcements.Queries.GetActiveAnnouncements
{
  public record GetActiveAnnouncementsQuery(string CompanyId, int BranchId) : IRequest<object>;
  public class GetActiveAnnouncementsQueryHandler : IRequestHandler<GetActiveAnnouncementsQuery, object>
  {
    private readonly ICoreApi _coreApi;

    public GetActiveAnnouncementsQueryHandler(ICoreApi coreApi)
    {
      _coreApi = coreApi;
    }

    public async Task<object> Handle(GetActiveAnnouncementsQuery request, CancellationToken cancellationToken)
    {
      var company = await _coreApi.GetCompanyById(request.CompanyId, cancellationToken);

      var requestBody = new ActiveAnnouncementsRequest
      {
        CompanyId = company.Data.CompanyId,
        BranchId = request.BranchId,
      };

      return await _coreApi.GetActiveAnnouncements(requestBody, cancellationToken);
    }
  }
}
