using gpt_integration.Models;

namespace gpt_integration.DTOs;

public class GPTChatDTO
{
    public string Model { get; private set; }
    public IEnumerable<GPTMessageDTO> Messages { get; private set; }
    public GPTChatDTO(Chat chat)
    {
        Model = chat.Model;
        Messages = chat.ChatMessages.Select(p => new GPTMessageDTO(p));
    }
}