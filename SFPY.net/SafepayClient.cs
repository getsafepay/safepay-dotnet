using System.Net.Http.Headers;

namespace Safepay;

public static class SafepayClient
{
  public static HttpClient ApiClient { get; set; }

  public static void InitializeApiClient(bool isDebug)
  {
    if (isDebug)
    {
      ApiClient = new HttpClient(new LoggingHandler(new HttpClientHandler()));
    }
    else
    {
      ApiClient = new();
    }
    
    ApiClient.DefaultRequestHeaders.Accept.Clear();
    ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
  }
}
