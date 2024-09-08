using Microsoft.EntityFrameworkCore;


namespace infrastructure.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Products table
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1000 },
                new Product { Id = 2, Name = "Smartphone", Price = 600 },
                new Product { Id = 3, Name = "Tablet", Price = 400 }
            );
        }
    }
}
