using eShopAPI.Models;

namespace eShopAPI.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();

        public Task<Product> GetProduct(int id);

        public Task<Product> AddProduct(Product product);
    }
}
