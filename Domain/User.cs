using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User : IdentityUser
    {
        public string Role { get; set; } 
    }
}

