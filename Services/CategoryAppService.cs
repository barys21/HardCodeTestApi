using HardCodeTestApi.Data;
using HardCodeTestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardCodeTestApi.Services
{
    public class CategoryAppService
    {
        private readonly ApplicationDbContext _context;

        public CategoryAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
