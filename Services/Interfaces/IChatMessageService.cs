using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs.Models;
using gpt_integration.Models;

namespace gpt_integration.Services.Interfaces;

public interface IChatMessageService
{
    Task<ChatMessage> SendMessage(string? userEmail, int chatId, SendMessageOnChatDTO messageOnChatDTO);
}
