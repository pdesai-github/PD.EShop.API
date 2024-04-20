using PD.EShop.Models.Implementations;
using PD.EShop.Models.Interfaces;

namespace PD.EShop.Products.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<IProduct>> GetProductsAsync();
        Task<IProduct> GetProductAsync(string id);
        Task AddProduct(Product product);
        Task UpdateProduct(string id, IProduct product);
        Task DeleteProduct(string id, string partitionKey);
    }
}
