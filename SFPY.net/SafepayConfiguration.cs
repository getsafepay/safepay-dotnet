namespace Safepay;

/// <summary> Global configuration class for Safe settings </summary>
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
          return SafepayEnvironment.Production;
        }

        return environment;
    }

    set
    {
        string env = value.ToLower();
        switch (env)
        {
          case SafepayEnvironment.Development:
          case SafepayEnvironment.Sandbox:
          case SafepayEnvironment.Production:
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
            case SafepayEnvironment.Development:
              return SafepayApiBase.Development;

            case SafepayEnvironment.Sandbox:
              return SafepayApiBase.Sandbox;

            case SafepayEnvironment.Production:
              return SafepayApiBase.Production;

            default:
              return SafepayApiBase.Production;
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
