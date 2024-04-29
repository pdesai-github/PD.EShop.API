using PD.EShop.Models.Implementations;

namespace PD.EShop.Orders.Services
{
    public interface IOrdersService
    {
        Task CreateOrder(Order order);
    }
}
