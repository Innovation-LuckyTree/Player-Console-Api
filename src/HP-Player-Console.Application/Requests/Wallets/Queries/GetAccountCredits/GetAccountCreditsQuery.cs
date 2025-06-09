using HP_Player_Console.Infrastructure.AccountServices.Models.Responses;
using MediatR;

namespace HP_Player_Console.Application.Requests.Wallets.Queries.GetAccountCredits;

public class GetAccountCreditsQuery : IRequest<AccountBalanceResponse> { }
