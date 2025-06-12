using HP_Player_Console.Infrastructure.Models;

namespace HP_Player_Console.Infrastructure.Core.Models.Responses.OTP;

public class OtpDataResponse : ApiBaseResponse<List<OtpData>>
{
}


public class OtpData
{
    public long ReferenceId { get; set; }
    public string MobileNumber { get; set; }
    public string Code { get; set; }
    public bool IsVerify { get; set; }
}
