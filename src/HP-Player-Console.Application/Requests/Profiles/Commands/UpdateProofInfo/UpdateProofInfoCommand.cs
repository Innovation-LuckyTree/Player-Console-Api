using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProofInfo;

public class UpdateProofInfoCommand : IRequest<object>
{
    public UpdateProofInfoRequest Data { get; set; }
}
