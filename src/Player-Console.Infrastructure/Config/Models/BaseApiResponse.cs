namespace HP_Player_Console.Infrastructure.Config.Models;

public class BaseApiResponse<T>
{
    public string ResponseCode { get; set; }
    public bool Success { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}
