using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Models;

namespace gpt_integration.DTOs.Models;

public class ChatDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public List<ChatMessagesDTO> ChatMessages { get; set; } = new ();

    public ChatDTO(Chat chat)
    {
        Id = chat.Id;
        Name = chat.Name;
        Model = chat.Model;
        ChatMessages = chat.ChatMessages.Select(p => new ChatMessagesDTO(p)).ToList();
    }

}
