namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;

public record FindPlayerRequest(Guid UserId, string CompanyId);
