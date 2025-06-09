using HP_Player_Console.Infrastructure.Core;
using HP_Player_Console.Infrastructure.Core.Models.Requests.Withdrawals;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Notifications.Transactions;

public record WithdrawalStatusNotification(long TransactionId, int Status) : INotification;

public class WithdrawalStatusNotificationHandler(ICoreAccountApi coreAccountApi) : INotificationHandler<WithdrawalStatusNotification>
{
    private readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task Handle(WithdrawalStatusNotification notification, CancellationToken cancellationToken)
    {
        var request = new UpdateWithdrawalStatusRequest
        {
            TransactionId = notification.TransactionId,
            Status = notification.Status
        };

        await _coreAccountApi.UpdateWithdrawalStatus(request, cancellationToken);
    }
}