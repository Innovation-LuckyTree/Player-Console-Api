namespace HP_Player_Console.Infrastructure.CoreIdentity.Models.Requests;

public record CreateUserDeviceTokenRequest(Guid UserId, string DeviceName, string DeviceModel);
