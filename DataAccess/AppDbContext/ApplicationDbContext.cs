using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> product { get; set; }

        public DbSet<Order> order { get; set; }

        public DbSet<OrderProduct> ordersProduct { get; set; }

    }
}
