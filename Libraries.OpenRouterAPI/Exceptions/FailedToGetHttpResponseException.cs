using System;

namespace Libraries.OpenRouterAPI.Exceptions;

public class FailedToGetHttpResponseException: Exception
{
    public FailedToGetHttpResponseException(string? url, string message) 
        : base($"Failed to get response from. Url: {url} {message}") 
    { 
        
    }
}
