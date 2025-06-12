namespace HP_Player_Console.Infrastructure.Core.Models.Requests.OTP;

public record VerifyOtpRequest(long ReferenceId, string MobileNumber, string OtpCode);
