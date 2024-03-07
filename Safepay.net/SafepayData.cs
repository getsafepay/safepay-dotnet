using System.Text.Json;
using System.Text.Json.Serialization;

namespace Safepay.net;

public class SafepayData
{
  public string Token { get; set; }

  [JsonPropertyName("user_id")]
  public string UserId { get; set; }

  public string Billing { get; set; }

  public string Client { get; set; }

  public double Amount { get; set; }
  
  public string Currency { get; set; }

  [JsonPropertyName("default_currency")]
  public string DefaultCurrency { get; set; }

  public double Discount { get; set; }

  public string Intent { get; set; }

  [JsonPropertyName("convertsion_rate")]
  public double ConversionRate { get; set; }

  public string Environment { get; set; }

  public string State { get; set; }

  [JsonPropertyName("created_at")]
  public string CreatedAt { get; set; }

  [JsonPropertyName("updated_at")]
  public string UpdatedAt { get; set; }

  [JsonPropertyName("automatic_currency_conversion")]
  public bool AutomaticCurrencyConversion { get; set; }

  private static readonly JsonSerializerOptions prettify = new()
  {
      WriteIndented = true
  };

  public override string ToString()
  {
    return JsonSerializer.Serialize(this, prettify);
  }
}

// TODO
  // "transaction": null,
  // "dynamic_currency_conversion": null,
  // "metadata": null,
