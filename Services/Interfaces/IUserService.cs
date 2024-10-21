using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Models;

namespace gpt_integration.Services.Interfaces;

public interface IUserService
{
    Task<User> GetUserByEmail(string? email);
}
