using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<object>;
    public class GetUserByIdQueryHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<GetUserByIdQuery, object>
    {
        private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

        public async Task<object> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _coreAccountApi.GetUserById(request.UserId, cancellationToken);
        }
    }
}
