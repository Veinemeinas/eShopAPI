using eShopAPI.Context;
using eShopAPI.Interfaces;
using eShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eShopAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly eShopContext _context;

        public ProductRepository(eShopContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
