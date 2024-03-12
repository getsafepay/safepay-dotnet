namespace Safepay
{
  using System.Text.Json;
  using System.Text.Json.Serialization;

  public class SafepayData
  {
    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("user_id")]
    public string UserId { get; set; }

    [JsonPropertyName("billing")]
    public string Billing { get; set; }

    [JsonPropertyName("client")]
    public string Client { get; set; }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currrency")]
    public string Currency { get; set; }

    [JsonPropertyName("default_currency")]
    public string DefaultCurrency { get; set; }

    [JsonPropertyName("discount")]
    public double Discount { get; set; }

    [JsonPropertyName("intent")]
    public string Intent { get; set; }

    [JsonPropertyName("convertsion_rate")]
    public double ConversionRate { get; set; }

    [JsonPropertyName("environment")]
    public string Environment { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonPropertyName("automatic_currency_conversion")]
    public bool AutomaticCurrencyConversion { get; set; }

    private static readonly JsonSerializerOptions prettify = new JsonSerializerOptions()
    {
      WriteIndented = true
    };

    public override string ToString()
    {
      return JsonSerializer.Serialize(this, prettify);
    }
  }
}