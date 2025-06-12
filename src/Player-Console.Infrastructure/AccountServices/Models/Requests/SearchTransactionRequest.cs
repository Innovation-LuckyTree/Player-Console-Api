namespace HP_Player_Console.Infrastructure.AccountServices.Models.Requests;

public class SearchTransactionRequest
{
    public Guid AccountId { get; set; }
    public string SearchKey { get; set; } = "";
    public int? TransactionType { get; set; } //0-credit , 1-debit
    public int Start { get; set; } = 0;
    public int PageSize { get; set; } = 20;
    public DateTime? StartDate { get; set; } = DateTime.Now.AddDays(-100);
    public DateTime? EndDate { get; set; } = DateTime.Now;
}
