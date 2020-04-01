using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public class UserDto
    {
        public string Token { get; set; }
        //public string UserName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
