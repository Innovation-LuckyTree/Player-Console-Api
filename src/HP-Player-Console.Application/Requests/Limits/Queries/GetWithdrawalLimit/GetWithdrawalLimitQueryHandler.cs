using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Application.Requests.Wallets.Queries;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Limits.Queries.GetWithdrawalLimit;

public class GetWithdrawalLimitQueryHandler(IAccountServiceApi accountServiceApi) : IRequestHandler<GetWithdrawalLimitQuery, ApiBaseResponse<WithdrawalTransactionVm>>
{
	private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;

	public async Task<ApiBaseResponse<WithdrawalTransactionVm>> Handle(GetWithdrawalLimitQuery request, CancellationToken cancellationToken)
	{
		var response = new ApiBaseResponse<WithdrawalTransactionVm>();
		var searchTransactionRequest = new SearchTransactionRequest
		{
			SearchKey = TransactionReferenceTypes.ACCOUNT_WITHDRAW,
			TransactionType = null,
			Start = 0,
			PageSize = 100,
			StartDate = DateTime.Now,
			EndDate = DateTime.Now,
		};

		try
		{
			var withdrawals = await _accountServiceApi.GetCreditTransactions<AccountDto>(searchTransactionRequest, cancellationToken);

			var withdrawalTransactions = withdrawals.Transactions;

			response.Data = new WithdrawalTransactionVm(withdrawalTransactions)
			{
				Size = withdrawals.TransactionCount,
				Offset = withdrawals.Offset,
				Total = withdrawals.TotalCount
			};
		}
		catch (Exception ex)
		{
			response.Success = false;
			response.ErrorMessage = ex.Message;
		}

		return response;
	}
}
