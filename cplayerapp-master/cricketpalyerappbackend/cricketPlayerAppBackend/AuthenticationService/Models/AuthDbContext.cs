using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Models
{
    public class AuthDbContext : DbContext
    {
        internal readonly object users;

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            //make sure that database is auto generated using EF Core Code first

            Database.EnsureCreated();
        }

        //Define a Dbset for User in the database
        public DbSet<User> Users { get; set; }

    }
}
