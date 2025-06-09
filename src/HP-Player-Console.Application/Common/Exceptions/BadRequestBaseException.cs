using HP_Player_Console.Common.Models;

namespace HP_Player_Console.Application.Common.Exceptions;

public class BadRequestBaseException : Exception
{
    public BadRequestBaseException(string errorMessage)
        : base(errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public object Data { get; set; }

    public ApiResponseBase<object> Response
    {
        get
        {
            return new ApiResponseBase<object>
            {
                Data = Data,
                ErrorMessage = ErrorMessage,
                ResponseCode = ErrorCode,
                Success = false
            };
        }

    }
}
