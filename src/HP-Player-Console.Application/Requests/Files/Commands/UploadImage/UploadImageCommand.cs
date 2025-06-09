using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HP_Player_Console.Application.Requests.Commands.UploadImage;

public record UploadImageCommand(IFormFile FormFile) : IRequest<UploadFileResponse>;
