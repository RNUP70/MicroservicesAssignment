namespace OrderService.Model
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public CustomerDto CustomerDetail { get; set; }
    }
}
