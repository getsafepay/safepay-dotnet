namespace Safepay
{
  using Newtonsoft.Json;

  public class Init
  {

    [JsonProperty("client")]
    public string Client { get; set; }

    [JsonProperty("environment")]
    public string Environment { get; set; }

    [JsonProperty("amount")]
    public double Amount { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }
  }
}