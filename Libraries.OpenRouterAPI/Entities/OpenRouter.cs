using Libraries.OpenRouterAPI.Entities.Configurations;
using Libraries.OpenRouterAPI.Interfaces;
using Microsoft.Extensions.Options;

namespace Libraries.OpenRouterAPI.Entities;

public class OpenRouter : IOpenRouter
{
    public string URL { get; set; }
    
    public IChatHttpClient Client { get; set; }

    public OpenRouter(IOptions<OpenRouterConfiguration> config)
        : this(config.Value.URL, config.Value.APIKey)
    {
        // do nothing
    }

    public OpenRouter(OpenRouterConfiguration config)
        : this(config.URL, config.APIKey)
    {
        // do nothing
    }

    public OpenRouter(string url, string APIKey)
    {
        this.URL = url;
        this.Client = new ChatHttpClient(this.URL, APIKey);
    }
}