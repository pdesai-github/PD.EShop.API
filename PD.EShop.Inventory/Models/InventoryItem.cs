using Newtonsoft.Json;

namespace PD.EShop.Inventory.Models
{
    public class InventoryItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId}, Product Name: {ProductName}, Quantity: {Quantity}, Price: {Price}, Category: {Category}, Location: {Location}";
        }
    }
}
