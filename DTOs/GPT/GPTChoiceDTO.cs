using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace gpt_integration.DTOs;

public class GPTChoiceDTO
{
    [JsonPropertyName("index")]
    public int? Index { get; set; }
    [JsonPropertyName("message")]
    public GPTMessageDTO? Message { get; set; }
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }
}
