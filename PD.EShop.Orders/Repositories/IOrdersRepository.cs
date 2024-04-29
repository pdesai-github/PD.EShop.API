using PD.EShop.Models.Implementations;

namespace PD.EShop.Orders.Repositories
{
    public interface IOrdersRepository
    {
        Task CreateOrder(Order order);
    }
}
