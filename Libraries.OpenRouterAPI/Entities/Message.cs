using Libraries.OpenRouterAPI.Enums;
using Newtonsoft.Json;

namespace Libraries.OpenRouterAPI.Entities;

    public class Message
    {
        [JsonProperty("role")]
        private string Role = "user";
        
        [JsonProperty("content")]
        public string? Content { get; set; }

        public static Message System(string Content)
        {
            return new Message()
            {
                Role = ChatRoleTypes.System.ToString().ToLower(),
                Content = Content
            };
        }

        public static Message User(string Content)
        {
            return new Message()
            {
                Role = ChatRoleTypes.User.ToString().ToLower(),
                Content = Content
            };
        }

        public static Message Assistant(string Content)
        {
            return new Message()
            {
                Role = ChatRoleTypes.Assistant.ToString().ToLower(),
                Content = Content
            };
        }

        public static Message Tool(string Content)
        {
            return new Message()
            {
                Role = ChatRoleTypes.Tool.ToString().ToLower(),
                Content = Content
            };
        }
    }