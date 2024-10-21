using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Enums;
using gpt_integration.Models;

namespace gpt_integration.DTOs.Models;

public class ChatMessagesDTO
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Message { get; set; }

    public ChatMessagesDTO(ChatMessage message)
    {
        Id = message.Id;
        Origin = message.Origin;
        Message = message.Message;
    }
}
