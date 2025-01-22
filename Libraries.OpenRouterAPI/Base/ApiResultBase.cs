using Newtonsoft.Json;

namespace Libraries.OpenRouterAPI.Base;

public abstract class ApiResultBase
{
    /// <summary>
    /// Which model was used to generate this result.
    /// </summary>
    [JsonProperty("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Object type, ie: text_completion, file, fine-tune, list, etc
    /// </summary>
    [JsonProperty("object")]
    public string? Object { get; set; }
}
