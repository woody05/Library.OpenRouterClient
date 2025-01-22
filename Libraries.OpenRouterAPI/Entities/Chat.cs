using Newtonsoft.Json;

namespace Libraries.OpenRouterAPI.Entities;

public class Choice
{
    /// <summary>
    /// Field for message back from LLM
    /// </summary>
    [JsonProperty("message")]
    public required Message Message { get; set; }
    
    /// <summary>
    /// Field for finish reason
    /// </summary>
    [JsonProperty("finish_reason")]
    public required string FinishReason { get; set; }
}