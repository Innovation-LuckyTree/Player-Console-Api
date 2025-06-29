using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using HP_Player_Console.Infrastructure.Interfaces;
using MediatR;

namespace HP_Player_Console.Application.Requests.Accounts.Queries.GetAccountCreditBalance
{
    public record GetAccountCreditBalanceQuery(Guid AccountCreditId) : IRequest<AccountBalanceResponse>;
    public class GetAccountCreditBalanceQueryHandler(IAccountServiceApi accountServiceApi) : IRequestHandler<GetAccountCreditBalanceQuery, AccountBalanceResponse>
    {
        private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;

        public async Task<AccountBalanceResponse> Handle(GetAccountCreditBalanceQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountServiceApi.GetAccountBalanceByAccountId(request.AccountCreditId, cancellationToken);

            return result;
        }
    }
}
