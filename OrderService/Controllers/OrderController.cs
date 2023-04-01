using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Model;
using Shared.Models;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus bus;

        public OrderController(IBus bus)
        {
            this.bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreatedOrder(OrderDto orderDto)
        {
            Uri uri = new Uri("rabbitmq://localhost/orderQueue");
            var endPoint = await bus.GetSendEndpoint(uri);
            
            var order = new Order
            {
                CustomerDetail = new Shared.Models.CustomerDto
                {
                    Address = orderDto.CustomerDetail.Address,
                    Email= orderDto.CustomerDetail.Email,
                    Name= orderDto.CustomerDetail.Name,
                    Id= orderDto.CustomerDetail.Id,
                },
                OrderId = orderDto.OrderId,
                ProductId = orderDto.ProductId,

            };
            await endPoint.Send(order);
            return Ok(orderDto);
        }
    }
}
