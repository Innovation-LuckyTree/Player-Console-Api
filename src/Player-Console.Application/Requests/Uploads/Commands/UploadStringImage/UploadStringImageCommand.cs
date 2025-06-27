using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Uploads.Commands.UploadStringImage
{
    public record UploadStringImageCommand(string Base64Image) : IRequest<object>;
    public class UploadStringImageCommandHandler(ICoreApi coreApi) : IRequestHandler<UploadStringImageCommand, object>
    {
        private readonly ICoreApi _coreApi = coreApi;

        public async Task<object> Handle(UploadStringImageCommand request, CancellationToken cancellationToken)
        {
            return await _coreApi.UploadBase64Image(new Infrastructure.Core.Models.Requests.FileUploads.UploadStringImage
            {
                Base64Image = request.Base64Image
            }, cancellationToken);
        }
    }
}
