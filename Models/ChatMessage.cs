using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs;
using gpt_integration.DTOs.Models;
using gpt_integration.Enums;

namespace gpt_integration.Models;

public class ChatMessage
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Message { get; set; }
    public Chat Chat { get; set; }
    public int ChatId { get; set; }
    
    public ChatMessage()
    {
        
    }

    public ChatMessage(SendMessageOnChatDTO messageOnChatDTO, int chatId)
    {
        Origin = nameof(MessageOrigins.USER);
        Message = messageOnChatDTO.Menssage;
        ChatId = chatId;
    }

    public ChatMessage(GPTChoiceDTO choiceDTO, int chatId)
    {
        Origin = nameof(MessageOrigins.ASSISTANT);
        Message = choiceDTO.Message!.Content;
        ChatId = chatId;
    }
}
