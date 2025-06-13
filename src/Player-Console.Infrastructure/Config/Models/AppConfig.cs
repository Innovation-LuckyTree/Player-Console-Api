using HP_Player_Console.Infrastructure.Interfaces;

namespace HP_Player_Console.Infrastructure.Config.Models;

public class AppConfig : IAppConfig
{
    public string AppId { get; set; }
    public JwtConfig JwtConfig { get; set; }
    public ApiClientConfig CoreIdentityApiClient { get; set; }
    public ApiClientConfig CoreApiClient { get; set; }
    public ApiClientConfig AccountServicesApiClient { get; set; }
    public ApiClientConfig SupportApiClient { get; set; }
    public ApiClientConfig PaymentServiceApiClient { get; set; }
    public ApiClientConfig HubClientApi { get; set; }
    public ApiClientConfig AddressApiClient { get; set; }
    public HuiduConfig HuiduClientApi { get; set; }
}
