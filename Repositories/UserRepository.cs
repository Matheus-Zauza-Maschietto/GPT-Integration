using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Models;
using gpt_integration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gpt_integration.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContect;
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContect = dbContext;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContect.Users.FirstOrDefaultAsync(p => p.Email == email);
    }

}
