using PD.EShop.Inventory.Models;

namespace PD.EShop.Inventory.Services
{
    public interface IInventoryService
    {
        Task PatchInventoryItemAsync(InventoryItem inventoryItem);
    }
}
