using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Exceptions;
using gpt_integration.Models;
using gpt_integration.Repositories.Interfaces;
using gpt_integration.Services.Interfaces;

namespace gpt_integration.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByEmail(string? email)
    {
        if(email is null) throw new BussinesException("Login invalido, faça login novamente.");
        User? user = await _userRepository.GetUserByEmail(email!);
        if(user is null) throw new BussinesException("Usuario não encontrado, faça login novamente.");
        return user;
    }

}
