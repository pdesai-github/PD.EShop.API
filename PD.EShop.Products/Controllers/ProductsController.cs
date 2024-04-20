using Microsoft.AspNetCore.Mvc;
using PD.EShop.Models.Implementations;
using PD.EShop.Models.Interfaces;
using PD.EShop.Products.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PD.EShop.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<IProduct>> Get()
        {
            return await _productsService.GetProductsAsync();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IProduct> Get(string id)
        {
            return await _productsService.GetProductAsync(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async void Post([FromBody] Product product)
        {
            await _productsService.AddProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPatch("{id}")]
        public async Task Patch(string id, [FromBody] Product product)
        {
            await _productsService.UpdateProduct(id, product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id, string partitionKey)
        {
            await _productsService.DeleteProduct(id,partitionKey);
        }
    }
}
