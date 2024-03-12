namespace Safepay
{
  using System;
  using System.Net.Http;
  using System.Text;
  using System.Text.Json;
  using System.Threading.Tasks;

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

      var body = new Init
      {
        Client = SafepayConfiguration.ApiKey,
        Environment = SafepayConfiguration.Environment.ToUpper(),
        Amount = amount,
        Currency = currency.ToUpper()
      };

      var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
      using (HttpResponseMessage response = await SafepayClient.ApiClient.PostAsync(url, content))
      {
        string Result = await response.Content.ReadAsStringAsync();
        SafepayResponse sfpyResponse = JsonSerializer.Deserialize<SafepayResponse>(Result);
        return sfpyResponse;
      }
    }
  }
}