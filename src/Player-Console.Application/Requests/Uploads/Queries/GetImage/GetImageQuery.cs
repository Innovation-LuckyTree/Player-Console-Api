using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Uploads.Queries.GetImage
{
    public record GetImageQuery(string UniqueFileName) : IRequest<object>;
    public class GetImageQueryHandler(ICoreApi coreApi) : IRequestHandler<GetImageQuery, object>
    {
        private readonly ICoreApi _coreApi = coreApi;

        public async Task<object> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            return await _coreApi.GetImageByName(request.UniqueFileName, cancellationToken);
        }
    }
}
