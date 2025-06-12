namespace HP_Player_Console.Application.Common.Exceptions;

public class WalletException : Exception
{
    public WalletException(string errorMessage)
        : base(errorMessage) { }
}