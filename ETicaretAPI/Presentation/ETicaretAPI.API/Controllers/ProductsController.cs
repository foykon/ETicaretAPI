﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> GetProducts()
        {
            return Ok(_productReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {

            }
            await _productWriteRepository.AddAsync(new()
            {
                Name= model.Name,
                Stock=model.Stock,
                Price=model.Price
            });
            await _productWriteRepository.SaveAsync();
            return Ok();
         }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await  _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
