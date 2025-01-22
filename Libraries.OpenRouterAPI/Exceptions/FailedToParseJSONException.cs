using System;

namespace Libraries.OpenRouterAPI.Exceptions;

public class FailedToParseJsonException : Exception
{
    public FailedToParseJsonException(string? url,string message) 
        : base($"Failed to parse JSON response from OpenRouter.  Url: {url} {message}"){}
}
