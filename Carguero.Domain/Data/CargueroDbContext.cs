using Carguero.Entities;
using Microsoft.EntityFrameworkCore;
namespace Carguero.Domain.Data
{
    public class CargueroDbContext : DbContext
    {
        public CargueroDbContext(DbContextOptions<CargueroDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.GetUsername())
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
