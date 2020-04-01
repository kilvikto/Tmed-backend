using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User : IdentityUser
    {
        public string Role { get; set; } 
        //public string Name { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string Surname { get; set; }
        //[MaxLength(6)]
        //public string Gender { get; set; }
        //public int Age { get; set; }
        //public string Address1 { get; set; }
        //public string Address2 { get; set; }

    }
}
