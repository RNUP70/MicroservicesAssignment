using System.ComponentModel.DataAnnotations;

namespace OrderService.Model
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
