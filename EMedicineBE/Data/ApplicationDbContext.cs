using EMedicineBE.Models;
using Microsoft.EntityFrameworkCore;

namespace EMedicineBE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        DbSet<Users> Users { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Medicines> Medicines { get; set; }
        DbSet<OrderItems> OrderItems { get; set; }
        DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
