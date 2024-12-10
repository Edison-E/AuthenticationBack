﻿using AuthBack.src.Application.DTO;
using AuthBack.src.Domain.Interface;

namespace AuthBack.src.Application.Service;

public class AccountService
{
    private readonly IUserRepository _userRepository;
    public AccountService(IUserRepository userrepository) 
    { 
     _userRepository = userrepository;
    }
    public async Task<bool> VerifyCredentials(LoginDTO login) => await _userRepository.VerifyCredentials(login);
   
}
