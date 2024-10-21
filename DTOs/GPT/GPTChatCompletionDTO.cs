using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpt_integration.DTOs;

public class GPTChatCompletionDTO
{
    public string? Id { get; set; }
    public string? Object { get; set; }
    public long? Created { get; set; }
    public string? Model { get; set; }
    public List<GPTChoiceDTO>? Choices { get; set; }
    public GPTUsageDTO? Usage { get; set; }
    public string? SystemFingerprint { get; set; }
}
