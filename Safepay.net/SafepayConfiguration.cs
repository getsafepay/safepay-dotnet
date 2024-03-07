namespace Safepay;

/// <summary> Global configuration class for Safepay settings </summary>
public static class SafepayConfiguration
{
  private static string apiKey;

  private static string environment;

  private static string apiBase;

  private static string webhookSecret;

  /// <summary> Gets or sets the API key. </summary>
  public static string ApiKey
  {
    get
    {
        return apiKey;
    }

    set
    {
        apiKey = value;
    }
  }

  /// <summary> Gets or sets the Environment. </summary>
  public static string Environment
  {
    get
    {
        if (string.IsNullOrEmpty(environment))
        {
          return Safepay.Environment.Production;
        }

        return environment;
    }

    set
    {
        string env = value.ToLower();
        switch (env)
        {
          case Safepay.Environment.Development:
          case Safepay.Environment.Sandbox:
          case Safepay.Environment.Production:
            environment = env;
            break;
        }
    }
  }

  /// <summary> Gets or sets the API Base. </summary>
  public static string ApiBase
  {
    get
    {
        if (string.IsNullOrEmpty(apiBase))
        {
          switch (Environment)
          {
            case Safepay.Environment.Development:
              return Safepay.ApiBase.Development;

            case Safepay.Environment.Sandbox:
              return Safepay.ApiBase.Sandbox;

            case Safepay.Environment.Production:
              return Safepay.ApiBase.Production;

            default:
              return Safepay.ApiBase.Production;
          }
        }

        return apiBase;
    }

    set
    {
        apiBase = value;
    }
  }

  /// <summary> Gets or sets the Webhook Secret. </summary>
  public static string WebhookSecret
  {
    get
    {
      return webhookSecret;
    }

    set
    {
      webhookSecret = value;
    }
  }
}
