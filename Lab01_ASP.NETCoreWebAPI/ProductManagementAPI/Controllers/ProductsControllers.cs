using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Dtos;
using ProductManagementAPI.Mappers;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        //GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetProducts() => repository.GetProducts();
        // POST: ProductsController/Products
        [HttpPost]
        public IActionResult PostProduct(CreateUpdateProductDto productDto)
        {
            repository.SaveProduct(ProductMapper.ToModelFromDto(productDto));
            return Ok();
        }

        // GET: ProductsController/Delete/5 [HttpDelete("id")]
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromQuery] int id)
        {
            var p = repository.GetProductById(id);

            if (p == null)
                return NotFound();
            repository.DeleteProduct(p);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromRoute] int id, [FromBody] CreateUpdateProductDto productDto)
        {
            var product = repository.UpdateProduct(id, ProductMapper.ToModelFromDto(productDto));

            if (product == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
