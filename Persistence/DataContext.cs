
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser> // it represents a session with the database, can be used to query and save instances of our entities.
    // DB context is a combination of the units of work and repository patterns.
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } // DBsets these represent the tables that we're going to create.
        // we added this class at services in program.cs 
    }
}