using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Commands.UploadImage;

public class UploadImageCommandHandler(ICoreApi coreApi) : IRequestHandler<UploadImageCommand, UploadFileResponse>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<UploadFileResponse> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        => await _coreApi.UploadImage(request.FormFile, cancellationToken);
}