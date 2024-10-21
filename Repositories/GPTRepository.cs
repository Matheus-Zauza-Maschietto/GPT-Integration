using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using gpt_integration.DTOs;
using gpt_integration.Enums;
using gpt_integration.Repositories.Interfaces;

namespace gpt_integration.Repositories;

public class GPTRepository : IGPTRepository
{
    private readonly HttpClient _gptClient;
    public GPTRepository(IHttpClientFactory factory)
    {
        _gptClient = factory.CreateClient(HttpClients.GPT.ToString());
    }

    public async Task<GPTChatCompletionDTO?> GenerateResponse(GPTChatDTO chat)
    {
        HttpResponseMessage response = await _gptClient.PostAsJsonAsync("v1/chat/completions", chat);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<GPTChatCompletionDTO?>(content);
    }

}
