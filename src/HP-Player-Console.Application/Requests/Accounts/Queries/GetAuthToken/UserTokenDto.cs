namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetUserToken;

public class UserTokenDto
{
    public Guid Id { get; set; }
    public Guid AccountObjectId { get; set; }
    public int IdNumber { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string ClientId { get; set; }
    public string Type { get; set; }
    public long ExpirationDate { get; set; }
    public bool Status { get; set; } = true;
}