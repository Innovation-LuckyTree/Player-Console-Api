using HP_Player_Console.Infrastructure.Interfaces;

namespace HP_Player_Console.Infrastructure.Config.Models;

public class AppConfig : IAppConfig
{
    public string AppId { get; set; }
    public JwtConfig JwtConfig { get; set; }
    public ApiClientConfig CoreIdentityApiClient { get; set; }
    public ApiClientConfig CoreApiClient { get; set; }
}
