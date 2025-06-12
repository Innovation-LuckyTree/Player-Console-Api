namespace HP_Player_Console.Infrastructure.Core.Models.Requests.Profiles;

public class UpdateProofInfoRequest
{
    public string ValidIdType { get; set; }
    public string FrontIdPath { get; set; }
    public string BackIdPath { get; set; }
    public string SelfiePath { get; set; }
    public string SignaturePath { get; set; }
}