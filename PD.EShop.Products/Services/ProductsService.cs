using PD.EShop.Models.Implementations;
using PD.EShop.Models.Interfaces;
using PD.EShop.Products.Repositories;

namespace PD.EShop.Products.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task AddProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            await _productsRepository.AddProduct(product);
        }

        public async Task DeleteProduct(string id, string partitionKey)
        {
            await _productsRepository.DeleteProduct(id, partitionKey);
        }

        public Task<IProduct> GetProductAsync(string id)
        {
            return _productsRepository.GetProductAsync(id);
        }

        public async Task<IEnumerable<IProduct>> GetProductsAsync()
        {
            return await _productsRepository.GetProductsAsync();
        }

        public async Task UpdateProduct(string id, IProduct product)
        {
           await _productsRepository.UpdateProduct(id, product);
        }
    }
}
