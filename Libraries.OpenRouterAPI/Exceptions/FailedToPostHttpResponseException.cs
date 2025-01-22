using System;

namespace Libraries.OpenRouterAPI.Exceptions;

public class FailedToPostHttpResponseException : Exception
{
    public FailedToPostHttpResponseException(string? url, string message) 
        : base($"Failed to get response from OpenRouter.  Url: {url} {message}") { }
}
