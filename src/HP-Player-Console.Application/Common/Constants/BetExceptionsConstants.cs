namespace HP_Player_Console.Application.Common.Constants;

public static class BetExceptionsConstants
{
    public const string NO_AVAILABLE_GAME_SCHEDULE = "No Available game schedule for the moment!";
    public const string CLOSED_GAME_SCHEDULE = "Betting Schedule is Closed";
    public const string MAX_BET_LIMIT = "Reached the maximum bet limit per game";
    public const string INSUFFICIENT_CREDIT_BALANCE = "Insufficient Credit Balance";
    public const string ORDER_EXCEPTION = "Create Order Exception: unable to connect server";
    public const string WALLET_CONNECTION_EXCEPTION = "Unable to connect to users wallet. Please try again";
    public const string ADD_BET_EXCEPTION = "Bet data preparation Exception";
    public const string PROCESS_ORDER_EXCEPTION = "PROCESSING ORDER EXCEPTION";
}