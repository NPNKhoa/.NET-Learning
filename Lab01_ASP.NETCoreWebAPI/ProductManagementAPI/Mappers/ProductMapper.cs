using BusinessObjects;
using ProductManagementAPI.Dtos;

namespace ProductManagementAPI.Mappers
{
    public static class ProductMapper
    {
        public static Products ToModelFromDto(this CreateUpdateProductDto dto)
        {
            return new Products
            {
                ProductName = dto.ProductName,
                CategoryId = dto.CategoryId,
                UnitsInStock = dto.UnitsInStock,
                UnitPrice = dto.UnitPrice,
            };
        }
    }
}
