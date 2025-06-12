using HP_Player_Console.Infrastructure.PaymentServices.Models;

namespace HP_Player_Console.Infrastructure.Interfaces;

public interface IPaymentServicesApi
{
    Task<object> GenerateQR(GenerateQRRequest request, CancellationToken cancellationToken);
    Task<object> AddCredit(AddCreditRequest request, CancellationToken cancellationToken);
    Task<object> SendWithdrawRequest(AddWithdrawRequest request, CancellationToken cancellationToken);
    Task<CreditTransactionResponse> GetPlayerRequestHistory(SearchWithdrawHistoryRequest request, CancellationToken cancellationToken);
}
