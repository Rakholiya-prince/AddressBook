using Microsoft.EntityFrameworkCore;

namespace Address_Book.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Industry> Industries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Industry>().HasData(
                new Industry { Industry_ID = 1, Industry_Name = "IT" },
                new Industry { Industry_ID = 2, Industry_Name = "Finance" },
                new Industry { Industry_ID = 3, Industry_Name = "Healthcare" }
            );
        }
    }
}
