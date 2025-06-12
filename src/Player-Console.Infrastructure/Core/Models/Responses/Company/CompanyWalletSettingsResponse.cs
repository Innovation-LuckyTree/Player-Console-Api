namespace HP_Player_Console.Infrastructure.Core.Models.Responses.Company;


public class CompanyWalletSettingsResponse
{
    public int WalletSettingId { get; set; }
    public int CompanyId { get; set; }
    public decimal InitialMinimumDeposit { get; set; }
    public decimal SubsequentMinimumDeposit { get; set; }
    public decimal MaximumDepositAtOnce { get; set; }
    public decimal MaximumDepositPerDay { get; set; }
    public decimal InitialMinimumWithdraw { get; set; }
    public decimal SubsequentMinimumWithdraw { get; set; }
    public decimal MaximumWithdrawAtOnce { get; set; }
    public decimal MaximumWithdrawPerDay { get; set; }
    public int TaxPercentage { get; set; }
    public decimal TaxAmount { get; set; }
}
