using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpt_integration.DTOs;

public class GPTChoiceDTO
{
    public int? Index { get; set; }
    public GPTMessageDTO? Message { get; set; }
    public string? FinishReason { get; set; }
}
