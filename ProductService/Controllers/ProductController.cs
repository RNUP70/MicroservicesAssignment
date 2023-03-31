using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            return Ok(ProductDataStore.Instance.Products);
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            var productToReturn = ProductDataStore.Instance.Products.FirstOrDefault(x => x.Id == productId);
            if (productToReturn == null)
            {
                return NotFound();
            }
            return Ok(productToReturn);
        }

        [HttpPost]
        public ActionResult<ProductDto> AddProduct(ProductCreationDto product)
        {
            var maxProductId = ProductDataStore.Instance.Products.Max(pd => pd.Id);

            var newProduct = new ProductDto()
            {
                Id = ++maxProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };

            ProductDataStore.Instance.Products.Add(newProduct);
            return CreatedAtRoute("GetProduct", new { productId = maxProductId }, newProduct);
        }

        [HttpPut("{productId}")]
        public ActionResult UpdateProduct(int productId, ProductUpdateDto productUpdateDto)
        {
            var productToBeUpdated = ProductDataStore.Instance.Products.FirstOrDefault(pd => pd.Id == productId);
            if (productToBeUpdated == null)
            {
                return NotFound();
            }

            productToBeUpdated.Name = productUpdateDto.Name;
            productToBeUpdated.Description = productUpdateDto.Description;
            productToBeUpdated.Price = productUpdateDto.Price;
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            var productToBeDeleted = ProductDataStore.Instance.Products.FirstOrDefault(pd => pd.Id == productId);
            if (productToBeDeleted == null)
            {
                return NotFound();
            }
            ProductDataStore.Instance.Products.Remove(productToBeDeleted);
            return NoContent();
        }

    }
}
