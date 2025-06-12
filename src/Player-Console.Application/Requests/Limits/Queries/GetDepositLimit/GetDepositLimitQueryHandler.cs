using HP_Player_Console.Application.Common.Enums;
using HP_Player_Console.Application.Requests.Wallets.Queries;
using HP_Player_Console.Infrastructure.AccountServices.Models.Requests;
using HP_Player_Console.Infrastructure.Interfaces;
using HP_Player_Console.Infrastructure.Models;
using MediatR;

namespace HP_Player_Console.Application.Requests.Limits.Queries.GetDepositLimit;

public class GetDepositLimitQueryHandler(IAccountServiceApi accountServiceApi) : IRequestHandler<GetDepositLimitQuery, ApiBaseResponse<DepositTransactionVm>>
{
	private readonly IAccountServiceApi _accountServiceApi = accountServiceApi;

	public async Task<ApiBaseResponse<DepositTransactionVm>> Handle(GetDepositLimitQuery request, CancellationToken cancellationToken)
	{
		var response = new ApiBaseResponse<DepositTransactionVm>();
		var searchTransactionRequest = new SearchTransactionRequest
		{
			SearchKey = TransactionReferenceTypes.ACCOUNT_CASH_IN,
			TransactionType = null,
			Start = 0,
			PageSize = 100,
			StartDate = DateTime.Now,
			EndDate = DateTime.Now,
		};

		try
		{
			var deposits = await _accountServiceApi.GetCreditTransactions<AccountDto>(searchTransactionRequest, cancellationToken);

			var depositTransactions = deposits.Transactions;

			response.Data = new DepositTransactionVm(depositTransactions)
			{
				Size = deposits.TransactionCount,
				Offset = deposits.Offset,
				Total = deposits.TotalCount
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
