using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Files.Queries;

public class GetImageByPathQueryHandler(ICoreApi coreApi) : IRequestHandler<GetImageByPathQuery, UploadFileResponse>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<UploadFileResponse> Handle(GetImageByPathQuery request, CancellationToken cancellationToken)
        => await _coreApi.GetImageByName(request.FileName, cancellationToken);
}
