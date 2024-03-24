using System;
using Microsoft.AspNetCore.Identity;

namespace BookStore_V2.Data
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
