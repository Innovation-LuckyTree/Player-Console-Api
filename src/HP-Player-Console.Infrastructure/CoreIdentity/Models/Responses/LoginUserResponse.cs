using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;

public class LoginUserResponse : ApiBaseResponse<UserLoginInfo>;

public class UserLoginInfo
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public int IdNumber { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }    
    public string ClientId { get; set; }
    public string Type { get; set; }
    public bool TemporaryPassword { get; set; }
    public bool IsLocked { get; set; }
    public long ExpirationDate { get; set; }
    public string CompanyId { get; set; }
}
