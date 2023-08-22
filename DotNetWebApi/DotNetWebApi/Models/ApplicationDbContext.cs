using Microsoft.EntityFrameworkCore;

namespace DotNetWebApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
