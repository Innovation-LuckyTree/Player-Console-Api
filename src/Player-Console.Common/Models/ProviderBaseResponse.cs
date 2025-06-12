namespace HP_Player_Console.Common.Models;

public class ProviderBaseResponse<T>
{
    public bool Ok { get; set; }
    public object Pagination { get; set; }
    public T Data { get; set; }
}