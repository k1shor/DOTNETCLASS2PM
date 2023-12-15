using Microsoft.EntityFrameworkCore;
using Webapp2pm.Models;

namespace Webapp2pm.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = 1,
                CategoryName = "Test"
            });
        }
    }
}
