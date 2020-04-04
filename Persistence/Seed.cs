using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Email = "john1997@gmail.com",
                        Role = "doctor"
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }
    }
}
