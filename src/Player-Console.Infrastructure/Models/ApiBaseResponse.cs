namespace HP_Player_Console.Infrastructure.Models;

public class ApiBaseResponse<T>
{
    public string ResponseCode { get; set; } = "200";
    public bool Success { get; set; } = true;
    public string? Status { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}
