using Microsoft.EntityFrameworkCore;
using TestWebapp.Models;

namespace TestWebapp.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}