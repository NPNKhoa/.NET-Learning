using ProductStore.Models;

namespace ProductStore.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<Product> CreateAsync(Product productModel);
        public Task<Product> UpdateAsync(Product productModel);
        public Task<Product> DeleteAsync(int id);
    }
}
