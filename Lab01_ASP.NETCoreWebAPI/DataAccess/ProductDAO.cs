using BusinessObjects;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Products> GetProducts()
        {
            var listProducts = new List<Products>();

            try
            {
                using (var context = new MyDbContext())
                {
                    listProducts = context.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listProducts;
        }

        public static Products FindProductById(int prodId)
        {
            Products p = new Products();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Products.SingleOrDefault(x => x.ProductId == prodId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static void SaveProduct(Products p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Products? UpdateProduct(int id, Products p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var existingProduct = context.Products.Find(id);

                    if (existingProduct == null)
                    {
                        return null;
                    }

                    existingProduct.ProductName = p.ProductName;
                    existingProduct.CategoryId = p.CategoryId;
                    existingProduct.UnitsInStock = p.UnitsInStock;
                    existingProduct.UnitPrice = p.UnitPrice;

                    context.SaveChanges();

                    return existingProduct;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Products p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Products.SingleOrDefault(
                                        c => c.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
