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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryAppService _categoryAppService;

        public CategoryController(CategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        // GET api/categories
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return  await _categoryAppService.GetAll();
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _categoryAppService.GetById(id);
        }

        // POST api/categories
        [HttpPost]
        public async Task Post(Category category)
        {
            await _categoryAppService.Create(category);
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public async Task Put(Category category)
        {
            await _categoryAppService.Update(category);
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _categoryAppService.Delete(id);
        }

    }
}
