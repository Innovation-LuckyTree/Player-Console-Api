namespace HP_Player_Console.Infrastructure.HuiduClient.Models;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class GetGamesPayload
{
    [JsonPropertyName("timestamp")]
    public string TimeStamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();

    [JsonPropertyName("agency_uid")]
    public string AgencyUid { get; set; }

    [JsonPropertyName("member_account")]
    public string MemberAccount { get; set; }

    [JsonPropertyName("game_uid")]
    public string GameUid { get; set; }

    [JsonPropertyName("credit_amount")]
    public string CreditAmount { get; set; } = "50.00";

    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; set; } = "PHP";

    [JsonPropertyName("language")]
    public string Language { get; set; } = "en";

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}