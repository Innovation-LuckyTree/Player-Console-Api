using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdatePersonalDetails;

public class UpdatePersonalDetailsCommand : IRequest<object>
{
    public UpdatePersonalDetailsRequest Data { get; set; }
}
