namespace Safepay
{
  using Newtonsoft.Json;
  public class SafepayStatus
  {
    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("errors")]
    public string[] Errors { get; set; }

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
  }
}