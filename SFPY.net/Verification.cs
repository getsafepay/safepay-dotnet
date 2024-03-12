namespace Safepay
{
  using System;
  using System.Linq;
  using System.Net.Http;
  using System.Security.Cryptography;
  using System.Text;

  public static class Verification
  {
    /// <summary>
    /// Verifies the Safepay Webhook signature against its content.
    /// </summary>
    /// 
    /// <param name="message"> The HTTP request message received in the Webhook payload. </param>
    /// 
    /// <returns></returns>
    public static bool VerifyWebhook(HttpRequestMessage message)
    {
      // Get the header values
      var values = message.Headers.GetValues("X-SFPY-SIGNATURE");
      if (values == null)
      {
        return false;
      }

      // Get the signature value
      string signature = values.FirstOrDefault();

      // Reconstruct the signature using the secret key
      string content = message.Content.ReadAsStringAsync().Result;
      string hmac = GetHMAC(content, SafepayConfiguration.WebhookSecret);

      // Validate the signature
      return string.Equals(signature, hmac, System.StringComparison.OrdinalIgnoreCase);
    }

    private static string GetHMAC(string text, string key)
    {
      using var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(key));
      var hash = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(text));
      return ToHexString(hash);
    }

    private static string ToHexString(byte[] input)
    {
      var hexString = BitConverter.ToString(input);
      return hexString.Replace("-", "");
    }
  }
}