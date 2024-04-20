using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.EShop.Models.Interfaces
{
    public interface IProduct
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }      
        string ImageUrl { get; set; }
        string CatagoryId { get; set; }
        string SubCategory { get; set; }
        string Brand { get; set; }      
        string Color { get; set; }
    }
}
