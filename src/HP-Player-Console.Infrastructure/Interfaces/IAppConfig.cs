using HP_Player_Console.Infrastructure.Config.Models;

namespace Badger.Web.Infrastructure.Interfaces;

public interface IAppConfig
{
    string AppId { get; set; }
    int GameId { get; set; }
    int RegularCompanyGame { get; set; }
    string MerchantName { get; set; }
    JwtConfig JwtConfig { get; set; }
    // ApiClientConfig CoreIdentityApiClient { get; set; }
    // ApiClientConfig CoreApiClient { get; set; }
    // ApiClientConfig WalletApiClient { get; set; }
}
