using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Interfaces;
using ProductStore.Models;

namespace ProductStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);   
        }
        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();

            return categoryModel;
        }

        public async Task<Category?> UpdateAsync(int id, Category CategoryModel)
        {
            var exisitingCategory = await _context.Categories.FindAsync(id);

            if (exisitingCategory == null)
            {
                return null;
            }

            exisitingCategory.CategoryName = CategoryModel.CategoryName;

            await _context.SaveChangesAsync();

            return exisitingCategory;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var deletedCategory = await _context.Categories.FindAsync(id);

            if (deletedCategory == null)
            {
                return null;
            }

            _context.Categories.Remove(deletedCategory);

            await _context.SaveChangesAsync();

            return deletedCategory;
        }
    }
}
