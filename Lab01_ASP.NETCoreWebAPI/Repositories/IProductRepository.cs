using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(Products p);
        Products GetProductById(int id);
        void DeleteProduct(Products p);
        Products? UpdateProduct(int id, Products p);
        List<Category> GetCategories();
        List<Products> GetProducts();
    }
}
