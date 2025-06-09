using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetUserToken;

public class GetAuthTokenQuery : IRequest<LoginUserResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string IpAddress { get; set; }
}
