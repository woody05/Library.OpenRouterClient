
using Libraries.OpenRouterAPI.Entities;

namespace Libraries.OpenRouterAPI.UnitTest;

public static class Program
{
    public static void Main(string[] args)
    {
        var api = new OpenRouter("https://openrouter.ai/api/v1/chat/completions", "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");

        var _params = new ChatRequest
        {
            Temperature = 0.0,
            Model = "openai/gpt-3.5-turbo",
            Messages = new List<Message>{
                    Message.System("You are a bot with extensive knowledge of pokemon. Write me a few paragraphs about pokemon in the tone and style of Donald Trump.")
                }
        };

        var result = api.Client.CreateChatCompletionAsync(_params).Result;

        Console.WriteLine(result.Choices?[0].Message.Content);
    }
}
