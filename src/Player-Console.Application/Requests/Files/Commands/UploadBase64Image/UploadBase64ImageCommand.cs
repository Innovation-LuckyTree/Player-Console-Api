using HP_Player_Console.Infrastructure.Core.Models.Requests.FileUploads;
using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using MediatR;

namespace HP_Player_Console.Application.Requests.Commands.UploadImage;

public class UploadBase64ImageCommand : IRequest<UploadFileResponse>
{
    public UploadStringImage Data { get; set; }
}
