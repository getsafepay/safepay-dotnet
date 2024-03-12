using System.Text.Json;
using System.Text.Json.Serialization;

namespace Safepay
{
  public class SafepayResponse
  {
    [JsonPropertyName("data")]
    public SafepayData Data { get; set; }

    [JsonPropertyName("status")]
    public SafepayStatus Status { get; set; }

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