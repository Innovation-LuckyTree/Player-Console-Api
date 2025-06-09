using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

public class ProviderAccountResponse : ApiResponseBase<ProviderBaseResponse<ProviderAccount>>
{
}

public class ProviderAccount
{
    public string Id { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }
    public string MobileNumber { get; set; }

    public long TransactionCount { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }
}