using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProfessionCommand;

public class UpdateProfessionCommand : IRequest<object>
{
    public UpdateProfessionRequest Data { get; set; }
}
