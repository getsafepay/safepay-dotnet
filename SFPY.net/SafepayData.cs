namespace Safepay
{
  using Newtonsoft.Json;

  public class SafepayData
  {
    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("billing")]
    public string Billing { get; set; }

    [JsonProperty("client")]
    public string Client { get; set; }

    [JsonProperty("amount")]
    public double Amount { get; set; }

    [JsonProperty("currrency")]
    public string Currency { get; set; }

    [JsonProperty("default_currency")]
    public string DefaultCurrency { get; set; }

    [JsonProperty("discount")]
    public double Discount { get; set; }

    [JsonProperty("intent")]
    public string Intent { get; set; }

    [JsonProperty("convertsion_rate")]
    public double ConversionRate { get; set; }

    [JsonProperty("environment")]
    public string Environment { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; }

    [JsonProperty("automatic_currency_conversion")]
    public bool AutomaticCurrencyConversion { get; set; }

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
  }
}