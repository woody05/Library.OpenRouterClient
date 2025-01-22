using Libraries.OpenRouterAPI.Entities;

namespace Libraries.OpenRouterAPI.Interfaces;

public interface IChatHttpClient
{
    Task<ChatResult> CreateChatCompletionAsync(ChatRequest request);

    Task<ChatResult> CreateChatCompletionAsync(ChatRequest request, int numOutputs);
}
