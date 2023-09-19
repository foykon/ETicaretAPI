using ETicaretAPI.Application.Repositories;
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
        public async void GetProducts()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 20},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 30 },
                new() { Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock = 40 },
                new() { Id = Guid.NewGuid(), Name = "Product 5", Price = 500, Stock = 50 },

        });
            await _productWriteRepository.SaveAsync();

        }

    }
}
