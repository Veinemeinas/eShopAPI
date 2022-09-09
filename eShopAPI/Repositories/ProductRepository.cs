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

        public async Task<int> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync();
        }
    }
}
