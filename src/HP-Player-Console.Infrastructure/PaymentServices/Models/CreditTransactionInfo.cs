namespace HP_Player_Console.Infrastructure.PaymentServices.Models;

public class CreditTransactionInfo
{
    public long Id { get; set; }
    public string AccountName { get; set; }
    public int AccountType { get; set; }
    public Guid SenderObjId { get; set; }
    public Guid ReceiverObjId { get; set; }
    public string RecieverAccountName { get; set; }
    public int RecieverAccountType { get; set; }
    public string TransNo { get; set; }
    public int TransType { get; set; }
    public decimal Amount { get; set; }
    public int Status { get; set; }
    public string Notes { get; set; }
    public string ProofImage { get; set; }
    public string CompanyName { get; set; }
    public string BranchName { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string TransTypeDesc { get; set; }
    public string StatusDesc { get; set; }
}
