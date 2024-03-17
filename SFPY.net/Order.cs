namespace Safepay
{
  using System.Net.Http;
  using System.Text;
  using System.Threading.Tasks;
  using Newtonsoft.Json;

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
    public static async Task<SafepayResponse> CreateTracker(double amount, string currency)
    {
      string url = $"{SafepayConfiguration.ApiBase}{Resources.Order}{Paths.OrderInit}";

      var body = new Init
      {
        Client = SafepayConfiguration.ApiKey,
        Environment = SafepayConfiguration.Environment.ToLower(),
        Amount = amount,
        Currency = currency.ToUpper()
      };

      var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
      using (HttpResponseMessage response = await SafepayClient.ApiClient.PostAsync(url, content))
      {
        string Result = await response.Content.ReadAsStringAsync();
        SafepayResponse sfpyResponse = JsonConvert.DeserializeObject<SafepayResponse>(Result);
        return sfpyResponse;
      }
    }
  }
}