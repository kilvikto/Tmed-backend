using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        [MaxLength(6)]
        public int Age { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }

    }
}
