namespace Safepay
{
  using Newtonsoft.Json;

  public class SafepayResponse
  {
    [JsonProperty("data")]
    public SafepayData Data { get; set; }

    [JsonProperty("status")]
    public SafepayStatus Status { get; set; }

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
  }
}