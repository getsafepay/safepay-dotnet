using System.Text.Json;
using System.Text.Json.Serialization;

namespace Safepay
{
  public class SafepayStatus
  {
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("errors")]
    public string[] Errors { get; set; }

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