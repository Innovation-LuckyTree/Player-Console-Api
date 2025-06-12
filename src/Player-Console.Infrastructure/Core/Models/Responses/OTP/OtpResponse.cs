using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;

public class OtpResponse : ApiBaseResponse<GenerateOtpData>
{
}

public class GenerateOtpData
{
    public long ReferenceId { get; set; }
    public Guid UserId { get; set; }
    public bool New { get; set; }
}