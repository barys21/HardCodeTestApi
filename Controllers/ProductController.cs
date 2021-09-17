using HardCodeTestApi.Models;
using HardCodeTestApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardCodeTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductAppService _productAppService;

        public ProductController(ProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET api/products
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _productAppService.GetAll();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productAppService.GetById(id);
        }

        // POST api/products
        [HttpPost]
        public async Task Post(Product product)
        {
            await _productAppService.Create(product);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task Put(Product product)
        {
            await _productAppService.Update(product);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _productAppService.Delete(id);
        }
    }
}
