using eShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eShopAPI.Context
{
    public class eShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public eShopContext(DbContextOptions options) : base(options) { }
    }
}
