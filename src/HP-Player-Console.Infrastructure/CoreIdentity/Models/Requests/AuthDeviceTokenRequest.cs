namespace HP_Player_Console.Infrastructure.CoreIdentity.Models.Requests;

public record AuthDeviceTokenRequest(Guid UserId, Guid TokenId, string Key, string IpAddress)
{
    public string TenantId { get; set; }
}
