using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;

public class UserAccessTokenResponse : ApiBaseResponse<UserAccessTokenInfo>;

public class UserAccessTokenInfo
{
    public long UserAccessTokenId { get; set; }
    public Guid UserId { get; set; }
    public long UserLogId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
    public Guid LogId { get; set; }
}