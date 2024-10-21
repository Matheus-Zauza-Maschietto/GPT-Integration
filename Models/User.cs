using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace gpt_integration.Models;

public class User : IdentityUser
{
    public List<Chat> Chats { get; set; }
}
