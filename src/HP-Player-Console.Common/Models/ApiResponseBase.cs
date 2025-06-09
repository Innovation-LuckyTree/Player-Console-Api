namespace HP_Player_Console.Common.Models;

public class ApiResponseBase<T>
{
    public string ResponseCode { get; set; }
    public bool Success { get; set; } = true;
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}
