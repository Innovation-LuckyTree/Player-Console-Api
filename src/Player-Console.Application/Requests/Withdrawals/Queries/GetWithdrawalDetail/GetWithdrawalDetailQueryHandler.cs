using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Withdrawals.Queries.GetWithdrawalDetail;

public class GetWithdrawalDetailQueryHandler(ICoreAccountApi coreAccountApi) : IRequestHandler<GetWithdrawalDetailQuery, object>
{
    public readonly ICoreAccountApi _coreAccountApi = coreAccountApi;

    public async Task<object> Handle(GetWithdrawalDetailQuery request, CancellationToken cancellationToken)
    {
        return await _coreAccountApi.GetWithdrawalDetail(request.TransactionId, cancellationToken);
    }
}
