using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs;
using gpt_integration.DTOs.Models;
using gpt_integration.Models;

namespace gpt_integration.Services.Interfaces;

public interface IChatService
{
    Task<Chat> CreateChatByUser(string? userEmail, CreateChatDTO chatDTO);
    Task<Chat> DeleteChat(string? userEmail, int id);
    Task<Chat> UpdateChat(string? userEmail, UpdateChatDTO chatDTO, int id);
    Task<IEnumerable<Chat>> ListChatsByUser(string? userEmail);
    Task<Chat> GetChatByUserAndId(string? userEmail, int id);
}
