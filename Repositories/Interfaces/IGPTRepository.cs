using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.DTOs;

namespace gpt_integration.Repositories.Interfaces;

public interface IGPTRepository
{
    Task<GPTChatCompletionDTO?> GenerateResponse(GPTChatDTO chat);
}
