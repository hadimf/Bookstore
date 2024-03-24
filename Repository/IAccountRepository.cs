using System;
using BookStore_V2.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore_V2.Repository
{
    public interface IAccountRepository
    {

        Task<IdentityResult> SignUp(SignUpDto model);
        Task<string> Login(LoginDto model);
    }
}
