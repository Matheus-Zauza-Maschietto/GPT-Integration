using gpt_integration.Models;
using gpt_integration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gpt_integration.Repositories;

public class ChatMessageRepository : IChatMessageRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ChatMessageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ChatMessage> CreateChatMessage(ChatMessage chatMessage)
    {
        ChatMessage createdMessage = _dbContext.ChatMessages.Add(chatMessage).Entity;
        await _dbContext.SaveChangesAsync();
        return createdMessage;
    }
    public async Task<IEnumerable<ChatMessage>> GetChatMessagesByChat(Chat chat)
    {
        return _dbContext.ChatMessages.AsNoTracking().Where(p => p.Chat.Id == chat.Id).OrderBy(p => p.Id);
    }
}
