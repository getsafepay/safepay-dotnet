using System.Net.Http.Json;

namespace Safepay;

public class Order
{
  /// <summary>
  /// Creates a new Tracker. A Tracker may be loaded into a Checkout session to capture a payment from a customer.
  /// </summary>
  /// 
  /// <param name="amount"> The order total. </param>
  /// <param name="currency" The base price currency. Three-letter ISO currency code, in uppercase. </param>
  /// 
  /// <returns></returns>
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
