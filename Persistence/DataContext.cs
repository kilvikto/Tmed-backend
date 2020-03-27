using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext: IdentityDbContext<User>
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Records> Records { get; set; }
        public DbSet<HealthComplaint> HealthComplaints { get; set; }
        public DbSet<BasicParameters> BasicParameters { get; set; }
        public DbSet<Pacient> Pacients { get; set; }

        public DataContext() : base()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Value>().HasData(
            //    new Value { Id = new Guid(), Name = "John", Surname = "Smith" }
            //    );
        }
    }
}
