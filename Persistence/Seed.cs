using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
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
