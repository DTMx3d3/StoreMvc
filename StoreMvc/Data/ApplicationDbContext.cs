using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreMvc.Models;

namespace StoreMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for Watch model
        public DbSet<Watch> Watches { get; set; }

        // DbSet for Cart model
        public DbSet<Cart> Carts { get; set; }

        // DbSet for CartDetail model
        public DbSet<CartDetail> CartDetails { get; set; }

        // DbSet for Order model
        public DbSet<Order> Orders { get; set; }

        // DbSet for OrderDetail model
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}