using Microsoft.Azure.Cosmos;
using PD.EShop.Models.Implementations;
using PD.EShop.Models.Interfaces;

namespace PD.EShop.Products.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseName;
        private const string _containerName = "Products";
        private readonly Container _container;

        public ProductsRepository(IConfiguration configuration)
        {           
            _cosmosClient = new CosmosClient(configuration["ConnectionStrings:CosmosDBConnection"]);
            _databaseName = configuration["CosmosDBDatabaseName"];
            _container = _cosmosClient.GetContainer(_databaseName, _containerName);
        }

        public async Task AddProduct(Product product)
        {
            await _container.CreateItemAsync(product, new PartitionKey(product.CatagoryId));
        }

        public async Task DeleteProduct(string id,string partitionKey)
        {
            await _container.DeleteItemAsync<Product>(id, new PartitionKey(partitionKey));
        }

        public async Task<IProduct> GetProductAsync(string id)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.id = @id")
                        .WithParameter("@id", id);

            var iterator = _container.GetItemQueryIterator<Product>(query);
            var response = await iterator.ReadNextAsync();

            return response.FirstOrDefault();
        }

        public async Task<IEnumerable<IProduct>> GetProductsAsync()
        {
            
            var query = new QueryDefinition("SELECT * FROM c");
            var iterator = _container.GetItemQueryIterator<Product>(query);

            var products = new List<IProduct>();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                products.AddRange(response.ToList());
            }

            return products;
        }

        public async Task UpdateProduct(string id, IProduct product)
        {
            ItemResponse<Product> response = await _container.PatchItemAsync<Product>(
                 id: product.Id,
                 partitionKey: new PartitionKey(product.CatagoryId),
                 patchOperations: new[] {
                    PatchOperation.Replace("/Price", product.Price),
                    PatchOperation.Replace("/Description", product.Description),
                    PatchOperation.Replace("/Name", product.Name),
                    PatchOperation.Replace("/Brand", product.Brand),
                    PatchOperation.Replace("/Color", product.Color)
                 }
             );

            Product updated = response.Resource;
        }
    }
}
