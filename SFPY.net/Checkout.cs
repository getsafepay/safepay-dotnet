namespace Safepay;

public static class Checkout
{
  /// <summary>
  /// Constructs the Safepay Checkout session URL
  /// </summary>
  ///
  /// <param name="trackerToken"> The token that identifies a tracker. </param>
  /// <param name="orderId"> An ID for identifying an order in your system. </param>
  /// <param name="cancelUrl"> The URL to which the user will be redirected when cancelling the order. </param>
  /// <param name="redirectUrl"> The URL to which the user will be redirected upon successful payment. </param>
  /// <param name="source"></param>
  /// <param name="usingWebhookVerification">
  /// When True, Checkout will redirect to `redirectUrl` and attach the `trackerToken` and `orderId`
  /// This also assumes that you will verify the payment event using Safepay Webhooks.
  /// If this is set to False and the `source` set to "custom", there will be no redirection.
  /// </param>
  /// 
  /// <returns> The absolute URL for the Safepay Checkout session. </returns>
  public static string CreateSession(string trackerToken, string orderId, string cancelUrl, string redirectUrl, string source = "custom", bool usingWebhookVerification = false)
  {
    // Determine the environment
    string checkoutBase = CheckoutBase.Production;
    switch (SafepayConfiguration.Environment)
    {
      case SafepayEnvironment.Development:
        checkoutBase = CheckoutBase.Development;
        break;

      case SafepayEnvironment.Sandbox:
        checkoutBase = CheckoutBase.Sandbox;
        break;
    }

    // Prepare the query params
    var queryParams = new Dictionary<string, string>()
    {
      {"beacon", trackerToken},
      {"order_id", orderId},
      {"env", SafepayConfiguration.Environment},
      {"cancel_url", cancelUrl},
      {"redirect_url", redirectUrl},
      {"source", source},
      {"webhooks", usingWebhookVerification.ToString().ToLower()}
    };

    // Construct the URL
    var uriBuilder = new UriBuilder(checkoutBase)
    {
        Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))
    };

    return uriBuilder.Uri.AbsoluteUri;
  }
}
