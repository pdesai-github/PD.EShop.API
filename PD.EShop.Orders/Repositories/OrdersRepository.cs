using Microsoft.Azure.Cosmos;
using PD.EShop.Models.Implementations;

namespace PD.EShop.Orders.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _containerName;

        private CosmosClient _cosmosClient;
        private Container _container;

        public OrdersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("OrdersConnectionString");
            _databaseName = _configuration["OrdersDatabaseName"];
            _containerName = _configuration["OrdersContainerName"];

            _cosmosClient = new CosmosClient(_connectionString);
            _container = _cosmosClient.GetContainer(_databaseName, _containerName);
        }
        public async Task CreateOrder(Order order)
        {
            await _container.CreateItemAsync<Order>(order, new PartitionKey(order.CustomerId));
        }
    }
}
