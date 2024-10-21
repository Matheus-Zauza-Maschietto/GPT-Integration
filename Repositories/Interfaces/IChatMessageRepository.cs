using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Models;

namespace gpt_integration.Repositories.Interfaces;

public interface IChatMessageRepository
{
    Task<ChatMessage> CreateChatMessage(ChatMessage chatMessage);
    Task<IEnumerable<ChatMessage>> GetChatMessagesByChat(Chat chat);
}
