using HardCodeTestApi.Data;
using HardCodeTestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardCodeTestApi.Services
{
    public class ProductAppService
    {
        private readonly ApplicationDbContext _context;

        public ProductAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(x => x.Categories).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
