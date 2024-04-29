using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PD.EShop.Models.Implementations;
using PD.EShop.Orders.Services;

namespace PD.EShop.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "order1", "order2" };
        }

        [HttpPost]
        public async void Post([FromBody] Order order)
        {
            await _ordersService.CreateOrder(order);
        }

    }
}
