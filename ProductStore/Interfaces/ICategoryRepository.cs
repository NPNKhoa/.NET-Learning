using ProductStore.Models;

namespace ProductStore.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);
        public Task<Category> CreateAsync(Category CategoryModel);
        public Task<Category?> UpdateAsync(int id, Category CategoryModel);
        public Task<Category?> DeleteAsync(int id);
    }
}
