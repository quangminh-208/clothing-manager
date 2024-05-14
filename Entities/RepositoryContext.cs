using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Clothing>? Clothings { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserOrder>? UserOrders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
    }
}
