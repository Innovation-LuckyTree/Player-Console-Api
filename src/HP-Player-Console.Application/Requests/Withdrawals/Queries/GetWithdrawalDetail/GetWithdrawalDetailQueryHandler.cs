using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetWithdrawalDetail;

public class GetWithdrawalDetailQueryHandler(ICoreApi coreApi) : IRequestHandler<GetWithdrawalDetailQuery, object>
{
    public readonly ICoreApi _coreApi = coreApi;

    public async Task<object> Handle(GetWithdrawalDetailQuery request, CancellationToken cancellationToken)
    {
        return await _coreApi.GetWithdrawalDetail(request.TransactionId, cancellationToken);
    }
}
