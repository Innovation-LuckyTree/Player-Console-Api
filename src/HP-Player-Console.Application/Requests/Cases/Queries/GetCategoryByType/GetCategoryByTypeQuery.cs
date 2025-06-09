using MediatR;

namespace HappyPlay.Application.Requests.Cases.Queries.GetCategoryByType;

public record GetCategoryByTypeQuery(int TypeId) : IRequest<object>;
