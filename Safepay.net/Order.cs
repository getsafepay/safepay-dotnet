using System.Net.Http.Json;

namespace Safepay.net;

public class Order
{
  public async Task<SafepayResponse> CreateTracker(double amount, string currency)
  {
    string url = $"{SafepayConfiguration.ApiBase}{Resources.Order}{Paths.OrderInit}";

    var body = new Init{
      Client = SafepayConfiguration.ApiKey,
      Environment = SafepayConfiguration.Environment.ToUpper(),
      Amount = amount,
      Currency = currency.ToUpper()
    };

    using (HttpResponseMessage response = await SafepayClient.ApiClient.PostAsJsonAsync(url, body))
    {
      SafepayResponse sfpyResponse = await response.Content.ReadFromJsonAsync<SafepayResponse>();
      return sfpyResponse;
    }
  }
}
