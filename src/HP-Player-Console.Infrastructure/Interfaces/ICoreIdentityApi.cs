using HP_Player_Console.Infrastructure.CoreIdentity.Models.Requests;
using HP_Player_Console.Infrastructure.CoreIdentity.Models.Responses;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface ICoreIdentityApi
{
    Task<LoginUserResponse> LoginUser(string userName, string password, string ipAddress, CancellationToken cancellationToken);
    Task<LoginUserResponse> LoginUserByTokenDevice(AuthDeviceTokenRequest request, CancellationToken cancellationToken);
    Task<LoginUserResponse> GetRefreshToken(string token, string refreshToken, CancellationToken cancellationToken);
    Task<UserDeviceTokenResponse> CreateUserDeviceToken(CreateUserDeviceTokenRequest request, CancellationToken cancellationToken);
    Task<UserAccessTokenResponse> GetUserAccessToken(Guid userId, Guid logId, CancellationToken cancellationToken);
}
