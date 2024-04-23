using PD.EShop.Inventory.Models;
using PD.EShop.Inventory.Repositories;

namespace PD.EShop.Inventory.Services
{
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task PatchInventoryItemAsync(InventoryItem inventoryItem)
        {
            await _inventoryRepository.PatchInventoryItemAsync(inventoryItem);
        }
    }
}
