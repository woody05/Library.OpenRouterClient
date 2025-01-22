using System;

namespace Libraries.OpenRouterAPI.Exceptions;

public class HttpNullResponseException : Exception
{
    public HttpNullResponseException(string? url, string? verb) 
        : base($"Response returned null. URL: {url} Action: {verb}")  
    { 

    }
}
