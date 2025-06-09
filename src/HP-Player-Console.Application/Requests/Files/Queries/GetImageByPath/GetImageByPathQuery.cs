using HP_Player_Console.Infrastructure.Core.Models.Responses.FileUploads;
using MediatR;

namespace HP_Player_Console.Application.Requests.Files.Queries;

public record GetImageByPathQuery(string FileName) : IRequest<UploadFileResponse>;
