using HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;
using MediatR;

namespace HP_Player_Console.Requests.Profiles.Commands.UpdateProfileImage;

public class UpdateProfileImageCommand : IRequest<object>
{
    public UpdateProfileImageRequest Data { get; set; }
}
