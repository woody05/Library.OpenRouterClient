using Libraries.OpenRouterAPI.Base;
using Newtonsoft.Json;


namespace Libraries.OpenRouterAPI.Entities;

public class ChatResult : ApiResultBase
{
    [JsonProperty("choices")]
    public List<Choice>? Choices { get; set; }

    [JsonProperty("usage")]
    public Usage? Usage { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("error")]
    public Error? Error { get; set; }

}

public class Error
{
    [JsonProperty("message")]
    public string? Message { get; set; }
    [JsonProperty("code")]
    public int Code { get; set; }
    [JsonProperty("metadata")]
    public MetaData? MetaData { get; set; }
}

public class MetaData
{
    [JsonProperty("reasons")]
    public string[]? Reasons { get; set; }
    [JsonProperty("flagged_input")]
    public string? FlaggedIntput { get; set; }
}