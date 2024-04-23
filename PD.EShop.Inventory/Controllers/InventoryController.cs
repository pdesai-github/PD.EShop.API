using Microsoft.AspNetCore.Mvc;
using PD.EShop.Inventory.Models;
using PD.EShop.Inventory.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PD.EShop.Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: api/<InventoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InventoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPatch]
        public async Task Patch([FromBody] InventoryItem inventoryItem)
        {
           await _inventoryService.PatchInventoryItemAsync(inventoryItem);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
