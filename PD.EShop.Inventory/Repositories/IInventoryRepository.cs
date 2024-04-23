using PD.EShop.Inventory.Models;

namespace PD.EShop.Inventory.Repositories
{
    public interface IInventoryRepository
    {      
        Task PatchInventoryItemAsync(InventoryItem inventoryItem);

    }
}
