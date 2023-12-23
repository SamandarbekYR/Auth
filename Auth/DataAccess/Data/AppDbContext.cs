using Auth.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace Auth.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User {  get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Host=localhost; Port=5432; User Id=postgres; Password=1234; Database=Auth;";
            optionsBuilder.UseNpgsql(connection);
        }
    }
}
