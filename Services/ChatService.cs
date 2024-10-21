using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs.Models;
using gpt_integration.Exceptions;
using gpt_integration.Models;
using gpt_integration.Repositories.Interfaces;
using gpt_integration.Services.Interfaces;

namespace gpt_integration.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public ChatService(
        IChatRepository chatRepository, 
        IUserService userService,
        IConfiguration configuration
    )
    {
        _configuration = configuration;
        _chatRepository = chatRepository;
        _userService = userService;
    }

    public async Task<Chat> CreateChatByUser(string? userEmail, CreateChatDTO chatDTO)
    {
        User user = await _userService.GetUserByEmail(userEmail);
        Chat chat = new Chat(chatDTO, user, _configuration["ChatGpt:Model"]);
        Chat newChat = await _chatRepository.CreateChat(chat);
        return newChat;
    }
    public async Task<Chat> DeleteChat(string? userEmail, int id)
    {
        User user = await _userService.GetUserByEmail(userEmail);
        Chat? chat = await _chatRepository.GetChatByIdAndUser(id, user);
        if(chat is null) throw new BussinesException("Chat não encontrado !");
        Chat deletedChat = await _chatRepository.DeleteChat(chat);
        return deletedChat;
    }
    public async Task<Chat> UpdateChat(string? userEmail, UpdateChatDTO chatDTO, int id)
    {
        User user = await _userService.GetUserByEmail(userEmail);
        Chat? chat = await _chatRepository.GetChatByIdAndUser(id, user);
        if(chat is null) throw new BussinesException("Chat não encontrado !");
        Chat updatedChat = await _chatRepository.UpdateChat(chat.UpdateChat(chatDTO));
        return updatedChat;
    }
    public async Task<IEnumerable<Chat>> ListChatsByUser(string? userEmail)
    {
        User user = await _userService.GetUserByEmail(userEmail);
        IEnumerable<Chat> chats = await _chatRepository.GetChatsByUser(user);
        return chats;
    }

    public async Task<Chat> GetChatByUserAndId(string? userEmail,  int id)
    {
        User user = await _userService.GetUserByEmail(userEmail);
        Chat? chat = await _chatRepository.GetChatByIdAndUser(id, user);
        if(chat is null) throw new BussinesException("Chat não encontrado !");
        return chat;
    }
}
