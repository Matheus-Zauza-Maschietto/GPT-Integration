using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs;
using gpt_integration.DTOs.Models;
using gpt_integration.Enums;
using gpt_integration.Exceptions;
using gpt_integration.Models;
using gpt_integration.Repositories.Interfaces;
using gpt_integration.Services.Interfaces;

namespace gpt_integration.Services;

public class ChatMessageService : IChatMessageService
{
    private readonly IChatService _chatService;
    private readonly IChatMessageRepository _chatMessageRepository;
    private readonly IGPTRepository _gptRepository;
    public ChatMessageService(
        IChatMessageRepository chatMessageRepository, 
        IGPTRepository gptRepository,
        IChatService chatService
    )
    {
        _chatService = chatService;
        _chatMessageRepository = chatMessageRepository;
        _gptRepository = gptRepository;
    }

    public async Task<ChatMessage> SendMessage(string? userEmail, int chatId, SendMessageOnChatDTO messageOnChatDTO)
    {
        Chat currentChat =  await _chatService.GetChatByUserAndId(userEmail, chatId);
        ChatMessage sendedMessage = new ChatMessage(messageOnChatDTO, currentChat.Id);
        currentChat.ChatMessages.Add(sendedMessage);
        currentChat.ChatMessages = GetRightContext(currentChat.ChatMessages).ToList();
        GPTChatCompletionDTO? completionDTO = await _gptRepository.GenerateResponse(new GPTChatDTO(currentChat));
        if(completionDTO is null) throw new IOException("Houve um erro ao entrar em contato com o chat gpt, por favor tente novamente !");
        ChatMessage userMessage = await _chatMessageRepository.CreateChatMessage(sendedMessage);
        ChatMessage gptMessage = new ChatMessage(completionDTO.Choices!.First(), currentChat.Id);
        ChatMessage assistantMessage = await _chatMessageRepository.CreateChatMessage(gptMessage);
        return assistantMessage;
    }

    private IEnumerable<ChatMessage> GetRightContext(List<ChatMessage> chatMessages)
    {
        if(chatMessages.Count <= 4)
        {
            return SetSystemContext(chatMessages).AsEnumerable();
        }
        List<ChatMessage> chatMessagesContext = new List<ChatMessage>();
        for (int i = chatMessages.Count-4; i < chatMessages.Count; i++)
        {
            chatMessagesContext.Add(chatMessages[i]);
        }
        return SetSystemContext(chatMessagesContext).AsEnumerable();
    }

    private List<ChatMessage> SetSystemContext(List<ChatMessage> chatMessages)
    {
        chatMessages.Insert(0, new ChatMessage(){
            Origin = nameof(MessageOrigins.SYSTEM),
            Message = "Você é um ajudante campones nascido em portugual no ano de 1500. Responda de acordo como tal !"
        });
        return chatMessages;
    }
}
