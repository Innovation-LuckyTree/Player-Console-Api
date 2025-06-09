using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetAuthByTokenDevice;

public class GetAuthByTokenDeviceQuery : IRequest<LoginUserResponse>
{
    public Guid UserId { get; set; }
    public Guid TokenId { get; set; }
    public string Key { get; set; }
    public string IpAddress { get; set; }
}
