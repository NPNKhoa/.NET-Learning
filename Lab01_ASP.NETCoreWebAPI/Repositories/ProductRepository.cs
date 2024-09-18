using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Products p) => ProductDAO.DeleteProduct(p);

        public void SaveProduct(Products p) => ProductDAO.SaveProduct(p);

        public Products? UpdateProduct(int id, Products p) => ProductDAO.UpdateProduct(id, p);

        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public List<Products> GetProducts() => ProductDAO.GetProducts();

        public Products GetProductById(int id) => ProductDAO.FindProductById(id);
    }
}
