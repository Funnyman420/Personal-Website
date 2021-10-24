using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PersonalWebsite.Persistence
{
    class PersonalWebsiteDbContext : DbContext
    {
        public PersonalWebsiteDbContext(DbContextOptions<PersonalWebsiteDbContext> options) : base(options)
        {
        }

        public DbSet<Blogger> Bloggers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
