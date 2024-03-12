using System.Text.Json.Serialization;

namespace Safepay
{
  public class Init
  {

    [JsonPropertyName("client")]
    public string Client { get; set; }

    [JsonPropertyName("environment")]
    public string Environment { get; set; }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
  }
}