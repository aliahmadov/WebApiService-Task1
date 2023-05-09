using Microsoft.EntityFrameworkCore;
using WebApi_Practice.Entities;

namespace WebApi_Practice.Data
{
    public class ECommerceDbContext:DbContext
    {

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options):base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
