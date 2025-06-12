namespace HP_Player_Console.Infrastructure.Models;

public class BadRequestResponse
{
    public string Type { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Detail { get; set; }
}
