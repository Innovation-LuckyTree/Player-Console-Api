using HP_Player_Console.Infrastructure.Config.Models;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface IAppConfig
{
    string AppId { get; set; }
    JwtConfig JwtConfig { get; set; }
    ApiClientConfig CoreIdentityApiClient { get; set; }
    ApiClientConfig CoreApiClient{ get; set; }
}
