using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.GetCaseById;

public class GetCaseByIdQueryHandler(ISupportClientApi supportApi) : IRequestHandler<GetCaseByIdQuery, object>
{
    private readonly ISupportClientApi _supportApi = supportApi;

    public async Task<object> Handle(GetCaseByIdQuery request, CancellationToken cancellationToken)
    {
        var caseTicket = await _supportApi.GetCaseById(request.CaseId, cancellationToken);

        var comments = await _supportApi.GetCaseComments(request.CaseId, cancellationToken);

        caseTicket.Comments = comments;

        return caseTicket;
    }
}