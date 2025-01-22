using System;
using Libraries.OpenRouterAPI.Entities;

namespace Libraries.OpenRouterAPI.Interfaces;

public interface IOpenRouter
{
    IChatHttpClient Client { get; set;}
}
