using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpt_integration.DTOs;

public class GPTUsageDTO
{
    public int? PromptTokens { get; set; }
    public int? CompletionTokens { get; set; }
    public int? TotalTokens { get; set; }
}
