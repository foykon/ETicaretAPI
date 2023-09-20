using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            this._productWriteRepository = productWriteRepository;
            this._productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task GetProducts()
        {
            //    await _productWriteRepository.AddRangeAsync(new()
            //    {
            //        new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 10 },
            //        new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 20},
            //        new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 30 },
            //        new() { Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock = 40 },
            //        new() { Id = Guid.NewGuid(), Name = "Product 5", Price = 500, Stock = 50 },

            //});
            //    await _productWriteRepository.SaveAsync();
            
            //tracking deneme
            Product product = await _productReadRepository.GetByIdAsync("19ad83d9-837f-425f-a2e1-7be52df61e32",false);
            product.Name = "mehmet";
            await _productWriteRepository.SaveAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
           Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
