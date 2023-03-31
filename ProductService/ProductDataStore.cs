using ProductService.Model;

namespace ProductService
{
    public class ProductDataStore
    {
        public List<ProductDto> Products { get; set; }

        public static ProductDataStore Instance { get; } = new ProductDataStore();

        public ProductDataStore()
        {
            Products = new List<ProductDto>()
            {
                new ProductDto() { Id = 1, Name = "Cricket Bat", Description = "Cricket Bat", Price = 100},
                new ProductDto() { Id = 2,Name = "Cricket Ball", Description = "Red Cricket Ball", Price = 50},
                new ProductDto() { Id = 3,Name = "Cricket Stumps", Description = "Cricket Stump",Price = 150}
            };
        }
    }
}

