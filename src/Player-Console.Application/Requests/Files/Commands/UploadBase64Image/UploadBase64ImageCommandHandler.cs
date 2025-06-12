using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Commands.UploadImage;

public class UploadBase64ImageCommandHandler(ICoreApi coreApi) : IRequestHandler<UploadBase64ImageCommand, UploadFileResponse>
{
    private readonly ICoreApi _coreApi = coreApi;

    public async Task<UploadFileResponse> Handle(UploadBase64ImageCommand request, CancellationToken cancellationToken)
        => await _coreApi.UploadBase64Image(request.Data, cancellationToken);
}