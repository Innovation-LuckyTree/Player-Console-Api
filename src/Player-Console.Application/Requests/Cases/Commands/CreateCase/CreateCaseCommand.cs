using HP_Player_Console.Infrastructure.Support.Requests;
using MediatR;

namespace HappyPlay.Application.Requests.Cases.Commands.CreateCase;

public class CreateCaseCommand : IRequest<object>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int? CategoryId { get; set; }
    public string? Comment { get; set; }
    public List<Attachment> Attachments { get; set; }
}
