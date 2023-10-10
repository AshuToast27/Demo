using Demo.web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.web.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
