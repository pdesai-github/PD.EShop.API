using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.EShop.Models.Implementations
{
    public class Order
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public string ProductQuantity { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
