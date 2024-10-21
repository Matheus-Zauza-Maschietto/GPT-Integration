using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace gpt_integration.DTOs;

public class GPTChatCompletionDTO
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("object")]
    public string? Object { get; set; }
    [JsonPropertyName("created")]
    public long? Created { get; set; }
    [JsonPropertyName("model")]
    public string? Model { get; set; }
    [JsonPropertyName("choices")]
    public List<GPTChoiceDTO>? Choices { get; set; }
    [JsonPropertyName("usage")]
    public GPTUsageDTO? Usage { get; set; }
    [JsonPropertyName("systemFingerprint")]
    public string? SystemFingerprint { get; set; }
}
