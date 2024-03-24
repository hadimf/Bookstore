using System;
using BookStore_V2.Models;
using BookStore_V2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_V2.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignUpDto model)
        {
            var result = await _accountRepository.SignUp(model);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors.Select(x => x.Description).ToList());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _accountRepository.Login(model);
            if (String.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
