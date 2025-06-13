using System.Text.Json.Serialization;

namespace HP_Player_Console.Infrastructure.HuiduClient.Models;

public class GetGamesRequest
{
    [JsonPropertyName("timestamp")]
    public string TimeStamp { get; set; }

    [JsonPropertyName("agency_uid")]
    public string AgencyUid { get; set; }
    
    [JsonPropertyName("payload")]
    public string Payload { get; set; }
}