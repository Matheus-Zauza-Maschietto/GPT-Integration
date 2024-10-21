using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs;
using gpt_integration.Models;

namespace gpt_integration.Repositories.Interfaces;

public interface IChatRepository
{
    Task<Chat> CreateChat(Chat chat);
    Task<Chat> DeleteChat(Chat chat);
    Task<Chat> UpdateChat(Chat chat);
    Task<Chat?> GetChatByIdAndUser(int id, User user);
    Task<IEnumerable<Chat>> GetChatsByUser(User user);
}
