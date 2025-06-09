using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateAddress;

public class UpdateAddressCommand : IRequest<object>
{
    public UpdateAddressRequest Data { get; set; }
}
    