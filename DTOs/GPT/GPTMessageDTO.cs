using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using gpt_integration.Models;

namespace gpt_integration.DTOs;

public class GPTMessageDTO
{
    [JsonPropertyName("role")]
    public string Role { get; set; }
    [JsonPropertyName("content")]
    public string Content { get; set; }
    public GPTMessageDTO(ChatMessage chatMessage)
    {
        Role = chatMessage.Origin.ToLower();
        Content = chatMessage.Message;
    }

    public GPTMessageDTO()
    {
        
    }
}
