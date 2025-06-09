namespace HP_Player_Console.Application.Common.Exceptions;

public class BetException : BadRequestBaseException
{
    public BetException(string errorMessage)
        : base(errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public BetException(string betExceptionType, string errorMessage)
        : base($"Error in betting due to {betExceptionType}. Error Message: {errorMessage}") { }
}
