namespace HP_Player_Console.Infrastructure.Config.Models;

public class JwtConfig
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
