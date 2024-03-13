namespace SFPY
{
  using System;
  using System.Net.Http;
  using System.Text;
  using System.Threading.Tasks;
  using Safepay;

  public class SFPYExample
  {
    public static async Task Main()
    {
      // Switch with your API key which is accessible from the merchant dashboard
      SafepayConfiguration.ApiKey = "sec_a7cc6fc1-088d-4f35-9dac-2bab2cb234a1";

      // Switch with your Webhook secret key which is accessible from the merchant dashboard
      SafepayConfiguration.WebhookSecret = "a30200d73f7e8a6c7bed2ef2b925d575eb198cf31d1145d9e52c102081cb6065";

      // The target environment
      SafepayConfiguration.Environment = "sandbox";

      // Test creating a tracker
      string checkout = await CreateTracker(100.50, "PKR");
      Console.WriteLine(checkout);

      // Test signature verification
      VerifySignature();
    }
    private static async Task<string> CreateTracker(double amount, string currency)
    {
      SafepayClient.InitializeApiClient(false);

      var response = await Order.CreateTracker(amount, currency);
      var data = response.Data;

      string checkout = Checkout.CreateSession(data.Token, "AX0000001", "https://google.com", "https://google.com", usingWebhookVerification: true);
      return checkout;
    }

    private static void VerifySignature()
    {
      var json = "{\"token\":\"CNK4P631F43C73AIIF7G\",\"client_id\":\"sec_c50daabe-49a4-4a62-8adf-25391c36e204\",\"type\":\"payment:created\",\"endpoint\":\"https://example.com\",\"notification\":{\"tracker\":\"track_69b331f2-5ef0-4dd5-bcb4-d288fbdac0ef\",\"reference\":\"969025\",\"intent\":\"CYBERSOURCE\",\"fee\":\"32.77\",\"net\":\"967.23\",\"user\":\"hzaidi@getsafepay.com\",\"state\":\"PAID\",\"amount\":\"1000.00\",\"currency\":\"PKR\",\"metadata\":{\"source\":\"checkout\"}},\"delivery_attempts\":1,\"resource\":\"notification\",\"next_attempt_at\":\"2024-03-06T10:59:36Z\",\"created_at\":\"2024-03-06T10:59:36Z\"}";
      var request = new HttpRequestMessage
      {
        RequestUri = new Uri("http://localhost/api/shoppingcart"),
        Content = new StringContent(json, Encoding.UTF8, "application/json")
      };
      request.Headers.Add("X-SFPY-SIGNATURE", "ed3b0a78fef22b658e0734a4d9072d148a2cc53c6ebade6323f9bfa6ea1658e5b603f8cea50de1f288707363663f42f50116d777ca634bca6f8ed1adfd462b1a");

      Console.WriteLine($"Verification: {Verification.VerifyWebhook(request)}");
    }
  }
}