using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.GetCaseById;

public record GetCaseByIdQuery(long CaseId) : IRequest<object>;
