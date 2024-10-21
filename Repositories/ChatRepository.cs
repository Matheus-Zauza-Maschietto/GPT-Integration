using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Models;
using gpt_integration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gpt_integration.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ChatRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Chat> CreateChat(Chat chat)
    {
        Chat createdChat = _dbContext.Chats.Add(chat).Entity;
        await _dbContext.SaveChangesAsync();
        return createdChat;
    }
    public async Task<Chat> DeleteChat(Chat chat)
    {
        Chat deletedChat = _dbContext.Chats.Remove(chat).Entity;
        await _dbContext.SaveChangesAsync();
        return deletedChat;
    }
    public async Task<Chat> UpdateChat(Chat chat)
    {
        Chat updatedChat = _dbContext.Chats.Update(chat).Entity;
        await _dbContext.SaveChangesAsync();
        return updatedChat;
    }
    public async Task<Chat?> GetChatByIdAndUser(int id, User user)
    {
        return await _dbContext
            .Chats.Include(p => p.ChatMessages)        
            .FirstOrDefaultAsync(p => p.Id == id && p.UserId == user.Id);
    }
    public async Task<IEnumerable<Chat>> GetChatsByUser(User user)
    {
        return await _dbContext.Chats.AsNoTracking().ToListAsync();
    }
}
