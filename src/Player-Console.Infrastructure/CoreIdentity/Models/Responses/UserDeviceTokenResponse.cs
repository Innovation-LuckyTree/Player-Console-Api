using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;

public class UserDeviceTokenResponse : ApiBaseResponse<UserDeviceTokenInfo>;

public class UserDeviceTokenInfo
{
    public Guid DeviceTokenId { get; set; }
    public string Key { get; set; }
    public string DeviceName { get; set; }
    public string DeviceModel { get; set; }
}
