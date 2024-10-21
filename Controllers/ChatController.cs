using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gpt_integration.DTOs.Models;
using gpt_integration.Exceptions;
using gpt_integration.Models;
using gpt_integration.Repositories.Interfaces;
using gpt_integration.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gpt_integration.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IChatMessageService _chatMessageService;

    public ChatController(
        IChatService chatService,
        IChatMessageService chatMessageService
    )
    {
        _chatMessageService = chatMessageService;
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat(
        [FromBody]CreateChatDTO chatDTO
    )
    {
        try
        {
            Chat newChat = await _chatService.CreateChatByUser(
                User.FindFirstValue(ClaimTypes.Email),
                chatDTO
            );
            return Ok(new ChatDTO(newChat));
        }
        catch(BussinesException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem("Houve um erro ao executar a seguinte função. por favor tente novamente mais tarde !");
        }
    }

    [HttpGet]
    public async Task<IActionResult> ListChats()
    {
        try
        {
            IEnumerable<Chat> chats = await _chatService.ListChatsByUser(User.FindFirstValue(ClaimTypes.Email));
            return Ok(chats.Select(p => new ChatDTO(p)));
        }
        catch(BussinesException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem("Houve um erro ao executar a seguinte função. por favor tente novamente mais tarde !");
        }
    }

    [HttpGet("{chatId:int}")]
    public async Task<IActionResult> GetChatById(
        [FromRoute]int chatId
    )
    {
        try
        {
            Chat chat = await _chatService.GetChatByUserAndId(User.FindFirstValue(ClaimTypes.Email), chatId);
            return Ok(new ChatDTO(chat));
        }
        catch(BussinesException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem("Houve um erro ao executar a seguinte função. por favor tente novamente mais tarde !");
        }
    }

    [HttpDelete("{chatId:int}")]
    public async Task<IActionResult> DeleteChatById(
        [FromRoute]int chatId
    )
    {
        try
        {
            Chat chat = await _chatService.DeleteChat(User.FindFirstValue(ClaimTypes.Email), chatId);
            return Ok(new ChatDTO(chat));
        }
        catch(BussinesException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem("Houve um erro ao executar a seguinte função. por favor tente novamente mais tarde !");
        }
    }

    [HttpPatch("{chatId:int}")]
    public async Task<IActionResult> UpdateChat(
        [FromBody]UpdateChatDTO chatDTO,
        [FromRoute]int chatId
    )
    {
        try
        {
            Chat chat = await _chatService.UpdateChat(User.FindFirstValue(ClaimTypes.Email), chatDTO, chatId);
            return Ok(new ChatDTO(chat));
        }
        catch(BussinesException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem("Houve um erro ao executar a seguinte função. por favor tente novamente mais tarde !");
        }
    }

    [HttpPost("{chatId:int}/Messages")]
    public async Task<IActionResult> SendMessageOnChat(
        [FromBody]SendMessageOnChatDTO messageDTO,
        [FromRoute]int chatId
    )
    {
        try
        {
            ChatMessage message = await _chatMessageService.SendMessage(User.FindFirstValue(ClaimTypes.Email), chatId, messageDTO);
            return Ok(new ChatMessagesDTO(message));
        }
        catch(BussinesException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            return Problem("Houve um erro ao executar a seguinte função. por favor tente novamente mais tarde !");
        }
    }
}
