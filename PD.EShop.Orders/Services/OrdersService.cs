
using Microsoft.Azure.Cosmos;
using PD.EShop.Models.Implementations;
using PD.EShop.Orders.Repositories;

namespace PD.EShop.Orders.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task CreateOrder(Order order)
        {
            order.Id = Guid.NewGuid().ToString();
            order.OrderDate = DateTime.Now.ToString();
            order.OrderId = Guid.NewGuid().ToString();
            await _ordersRepository.CreateOrder(order);
        }
    }
}
