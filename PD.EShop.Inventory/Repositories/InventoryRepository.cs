using Microsoft.Azure.Cosmos;
using PD.EShop.Inventory.Models;

namespace PD.EShop.Inventory.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _containerName;
        private readonly string _databaseName;

        private CosmosClient _cosmosClient;
        private Container _container;

        public InventoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("InventoryConnectionString");
            _containerName = _configuration["InventoryContainerName"];
            _databaseName = _configuration["InventoryDatabaseName"];

            _cosmosClient = new CosmosClient(_connectionString);
            _container = _cosmosClient.GetContainer(_databaseName, _containerName);
        }
     
        public async Task PatchInventoryItemAsync(InventoryItem inventoryItem)
        {
            await _container.PatchItemAsync<InventoryItem>(inventoryItem.Id,
                new PartitionKey(inventoryItem.ProductId),
                patchOperations: new[] {
                    PatchOperation.Replace("/quantity", inventoryItem.Quantity)
                    }
                );

        }
    }
}
