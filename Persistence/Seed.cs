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
                        Name = "John",
                        DateOfBirth = DateTime.Parse("1997-12-14"),
                        UserName = "john1997",
                        Email = "john1997@gmail.com",
                        Age = 22,
                        Gender = "male",
                        Address1 = "Prague",
                        Address2 = "Amerika",
                        Surname = "Black"
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            if(!context.Values.Any())
            {
                var values = new List<Value>
                {
                    new Value { Name = "John", Surname= "Black"},
                    new Value { Name = "Sara", Surname="Conor"}
                };
                await context.Values.AddRangeAsync(values);
                await context.SaveChangesAsync();
            }
        }
    }
}
