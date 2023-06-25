namespace Cepster.Core.BrasilApi;

public class Configuration
{
    public Configuration(string baseUrl)
    {
        BaseUrl = baseUrl;
    }

    public string BaseUrl { get; set; }
}
