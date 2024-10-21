using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs.Models;
using gpt_integration.Enums;

namespace gpt_integration.Models;

public class Chat
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public List<ChatMessage> ChatMessages { get; set; } = new ();
    public User User { get; set; }
    public string UserId { get; set; }
    public Chat()
    {
        
    }

    public Chat(CreateChatDTO chatDTO, User user, string model)
    {
        Model = model;
        Name = chatDTO.Name;
        User = user;
        UserId = user.Id;
    }

    public Chat UpdateChat(UpdateChatDTO chatDTO)
    {
        Name = chatDTO.Name;
        return this;
    }
}
