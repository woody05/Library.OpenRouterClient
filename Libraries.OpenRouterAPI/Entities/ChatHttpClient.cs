using Libraries.OpenRouterAPI.Base;
using Libraries.OpenRouterAPI.Interfaces;

namespace Libraries.OpenRouterAPI.Entities;

/// <summary>
/// Class for Open Router Chat client
/// </summary>
public class ChatHttpClient : HttpClientBase, IChatHttpClient
{
    /// <summary>
    /// Constructor for chat client
    /// </summary>
    /// <param name="url"></param>
    /// <param name="apiKey"></param>
    public ChatHttpClient(string url, string apiKey)
        : base(url)
    {
        if (_client is HttpClient httpClient && !httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
        }
    }

    /// <summary>
    /// Function to send a chat request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<ChatResult> CreateChatCompletionAsync(ChatRequest request)
    {
        return await HttpPostRequest<ChatResult>(null, postData: request);
    }

    /// <summary>
    /// Function to send a chat request with a number of outputs
    /// </summary>
    /// <param name="request"></param>
    /// <param name="numOutputs"></param>
    /// <returns></returns>
    public Task<ChatResult> CreateChatCompletionAsync(ChatRequest request, int numOutputs = 5)
    {
        request.NumChoicesPerMessage = numOutputs;
        return CreateChatCompletionAsync(request);
    }
}
