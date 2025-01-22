using Newtonsoft.Json;

namespace Libraries.OpenRouterAPI.Entities;

public class ChatRequest
{
    [JsonProperty("model")]
    public required string Model { get; set; }
    
    [JsonProperty("temperature")]
    public double Temperature { get; set; } = 0.880;
    
    [JsonProperty("top_p")]
    public double TopP { get; set; } = 1.0;
    
    [JsonProperty("max_tokens")]
    public int MaxTokens { get; set; } = 300;
    
    [JsonProperty("messages")]
    public List<Message> Messages { get; set; } = new List<Message>();
    
    [JsonProperty("stream")]
    public bool Stream { get; internal set; } = false; // TODO find away to implement the streaming response
    
    [JsonProperty("n")]
    public int? NumChoicesPerMessage { get; set; }
    
    [JsonProperty("frequency_penalty")]
    public double? FrequencyPenalty { get; set; }
    
    [JsonProperty("presence_penalty")]
    public double? PresencePenalty { get; set; }
    
    [JsonProperty("user")]
    public string? User { get; set; }
    
    [JsonIgnore]
    public string ResponseFormat { get; set; } = "text";
}
