using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore_V2.Models
{
    public class LoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
