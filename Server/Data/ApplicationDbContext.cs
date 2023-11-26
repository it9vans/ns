using Microsoft.EntityFrameworkCore;
using Shared;

namespace Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order>? Orders { get; set; } = null;
        public DbSet<Product>? Products { get; set; } = null;
        public DbSet<OrderProduct>? OrdersProducts { get; set; } = null;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=svk;Trusted_Connection=True;");
        }
    }
}
