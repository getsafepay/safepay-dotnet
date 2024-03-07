# Safepay.net

The official [Safepay][safepay] .NET library, supporting .NET Standard 8.0.2+.

## Usage

### Imports

```
using Safepay;
using Safepay.net;
```

### Configuration

Configure your client with the following keys that may be obtained from the merchant dashboard.

```
// Your merchant API key
SafepayConfiguration.ApiKey = "sec_a7cc6fc1-088d-4f35-9dac-2bab2cb234a1";

// Your webhook secret
SafepayConfiguration.WebhookSecret = "a30200d73f7e8a6c7bed2ef2b925d575eb198cf31d1145d9e52c102081cb6065";

// The target environment. This is set to production by default.
SafepayConfiguration.Environment = "sandbox";
```

### Creating a Safepay Checkout session

To create a Safepay Checkout session, you must create a Tracker and then generate a session URL. You should then redirect your customer to the Checkout URL.

Creating a tracker requires an amount and a currency.

| Parameter  | Type           | Required |
| ---------- | -------------- | -------- |
| `amount`   | `float`        | Yes      |
| `currency` | `PKR` or `USD` | Yes      |

You must specify the following when generating the Checkout session:

| Parameter     | Type      | Description                                                 | Required |
| ------------- | --------- | ----------------------------------------------------------- | -------- |
| `token`       | `string`  | The Tracker token                                           | Yes      |
| `orderId`     | `string`  | Your internal invoice / order id                            | Yes      |
| `cancelUrl`   | `string`  | Url to redirect to if user cancels the flow                 | Yes      |
| `redirectUrl` | `string`  | Url to redirect to if user completes the flow               | Yes      |
| `source`      | `string`  | Optional, defaults to `custom`                              | No       |
| `webhooks`    | `boolean` | Optional, defaults to `false`. Set to true for redirection  | No       |

An example is shown below:

```
// Initialize the HTTP client
SafepayClient.InitializeApiClient(false);

// Create a Tracker with the desired amount and currency
Order order = new();
var response = await order.CreateTracker(100.50, "PKR");
var data = response.Data;

// Generate the Checkout session URL
var checkout = Checkout.CreateSession(data.Token, "AX0000001", "https://google.com", "https://google.com", usingWebhookVerification:true);
```

### Verifying a Safepay Webhook payload

You may subscribe to various events from Safepay from the **Webhooks** tab in the **Developer** section on the merchant dashboard. To verify the contents of the Webhook, you may refer to the following snippet.

```
// Create an example payload
var json = "{\"token\":\"CNK4P631F43C73AIIF7G\",\"client_id\":\"sec_c50daabe-49a4-4a62-8adf-25391c36e204\",\"type\":\"payment:created\",\"endpoint\":\"https://example.com\",\"notification\":{\"tracker\":\"track_69b331f2-5ef0-4dd5-bcb4-d288fbdac0ef\",\"reference\":\"969025\",\"intent\":\"CYBERSOURCE\",\"fee\":\"32.77\",\"net\":\"967.23\",\"user\":\"hzaidi@getsafepay.com\",\"state\":\"PAID\",\"amount\":\"1000.00\",\"currency\":\"PKR\",\"metadata\":{\"source\":\"checkout\"}},\"delivery_attempts\":1,\"resource\":\"notification\",\"next_attempt_at\":\"2024-03-06T10:59:36Z\",\"created_at\":\"2024-03-06T10:59:36Z\"}";

// Construct the request with the payload and the matching signature
var request = new HttpRequestMessage {
  RequestUri = new Uri("http://localhost/api/shoppingcart"),
  Content = new StringContent(json, Encoding.UTF8, "application/json")
};
request.Headers.Add("X-SFPY-SIGNATURE", "ed3b0a78fef22b658e0734a4d9072d148a2cc53c6ebade6323f9bfa6ea1658e5b603f8cea50de1f288707363663f42f50116d777ca634bca6f8ed1adfd462b1a");

// Verify that the Webhook was sent by Safepay
bool isValid = Verification.VerifyWebhook(request);
```

[safepay]: https://getsafepay.com
