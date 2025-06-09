namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Accounts;

public class UpdateUserPasswordRequest
{
    public Guid UserId { get; set; }
    public string MobileNumber { get; set; }
    public long OtpReferenceId { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}
