using Carguero.Models;
using Microsoft.EntityFrameworkCore;
namespace Carguero.Domain.Data
{
    public class CargueroContext : DbContext
    {
        public CargueroContext(DbContextOptions<CargueroContext> options)
        : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
