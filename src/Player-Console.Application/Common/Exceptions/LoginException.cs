namespace HP_Player_Console.Application.Common.Exceptions;

public class LoginException : Exception
{
    public LoginException(string userName)
        : base($"The user entered an invalid user credential for username : {userName}!") { }

    public LoginException(string userName, string errorMessage)
        : base($"Failed to login username : {userName}. Error Message: {errorMessage}") { }

    public string ErrorCode { get; set; }
}