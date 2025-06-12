using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetWalletBalance;

public class GetWalletBalanceQuery : IRequest<AccountBalanceResponse> { }
