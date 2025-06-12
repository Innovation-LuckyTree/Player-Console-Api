using HP_Player_Console.Infrastructure.Core.Models.Responses.Account;

namespace HP_Player_Console.Infrastructure.PaymentServices.Models;

public class AddWithdrawRequest
{
    public AddWithdrawRequest()
    {

    }

    public AddWithdrawRequest(PlayersAgentResponse playersAgentResponse)
    {
        ReceiverObj = new PaymentAccount(playersAgentResponse.Agent)
        {
            AccountType = 4
        };
        
        SenderObj = new PaymentAccount(playersAgentResponse.Player)
        {
            AccountType = 5
        };

        CompanyName = playersAgentResponse.CompanyName;
        BranchName = playersAgentResponse.BranchName;
        ProofImage = "";
        SenderCreditId = playersAgentResponse.Player.AccountObjId;
        ReceiverCreditId = playersAgentResponse.Agent.AccountObjId;        
    }

    public PaymentAccount SenderObj { get; set; }
    public PaymentAccount ReceiverObj { get; set; }
    public int CreditType { get; set; } = 3;
    public decimal Amount { get; set; }
    public string CompanyName { get; set; }
    public string BranchName { get; set; }
    public string ProofImage { get; set; }
    public Guid SenderCreditId { get; set; }
    public Guid ReceiverCreditId { get; set; }
}
